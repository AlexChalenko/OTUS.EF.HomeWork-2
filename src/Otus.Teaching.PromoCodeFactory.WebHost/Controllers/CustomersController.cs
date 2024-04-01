using Microsoft.AspNetCore.Mvc;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.WebHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Клиенты
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IRepository<Customer> _customerRepository;
    private readonly IRepository<Preference> _preferenceRepository;
    private readonly IRepository<PromoCode> _promoCodeRepository;
    private readonly IRepository<CustomerPreference> _customerPreferencesRepository;

    public CustomersController(IRepository<Customer> customerRepository, IRepository<Preference> preferenceRepository, IRepository<PromoCode> promoCodeRepository, IRepository<CustomerPreference> customerPreferencesRepository)
    {
        _customerRepository = customerRepository;
        _preferenceRepository = preferenceRepository;
        _promoCodeRepository = promoCodeRepository;
        _customerPreferencesRepository = customerPreferencesRepository;
    }

    /// <summary>
    /// Получение списка клиентов
    /// </summary>
    /// <returns>Список всех клиентов </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerShortResponse>>> GetCustomersAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        var response = customers.Select(c => new CustomerShortResponse
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            Email = c.Email
        });

        return Ok(response);
    }

    /// <summary>
    /// Получение клиента по Id вместе с его предпочтениями и промокодами
    /// </summary>
    /// <param name="id">Id клиента</param>
    /// <returns>Информация о клиенте</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerResponse>> GetCustomerAsync(Guid id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);

        if (customer == null)
        {
            return NotFound($"Клиент с Id {id} не найден.");
        }

        var preferences = customer.CustomerPreferences.Select(p => new PreferenceResponse
        {
            Id = p.Id,
            Name = p.Preference.Name
        }).ToList();

        var promocodes = customer.PromoCodes.Select(pc => new PromoCodeShortResponse
        {
            Id = pc.Id,
            Code = pc.Code,
            ServiceInfo = pc.ServiceInfo,
            PartnerName = pc.PartnerManager.FullName,
            BeginDate = pc.BeginDate.ToString(),
            EndDate = pc.EndDate.ToString()
        }).ToList();

        var response = new CustomerResponse
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            Preferences = preferences,
            PromoCodes = promocodes,
        };

        return Ok(response);
    }

    /// <summary>
    /// Создание нового клиента вместе с его предпочтениями.
    /// </summary>
    /// <param name="request">Запрос на создание клиента.</param>
    /// <returns>Результат операции.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateCustomerAsync(CreateOrEditCustomerRequest request)
    {
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            CustomerPreferences = new List<CustomerPreference>()
        };

        foreach (var preferenceId in request.PreferenceIds)
        {
            customer.CustomerPreferences.Add(new CustomerPreference
            {
                Id = Guid.NewGuid(),
                CustomerId = customer.Id,
                PreferenceId = preferenceId
            });
        }

        // Сохраняем клиента и его предпочтения в базу данных
        await _customerRepository.AddAsync(customer);

        // Возвращаем результат. Например, можно вернуть созданного клиента.
        //return CreatedAtAction(nameof(GetCustomerAsync), new { id = customer.Id }, customer);
        return Ok($"Пользователь успешно создан {customer.Id}");
    }


    /// <summary>
    /// Обновление данных клиента вместе с его предпочтениями.
    /// </summary>
    /// <param name="id">Id клиента для обновления.</param>
    /// <param name="request">Запрос на обновление клиента.</param>
    /// <returns>Результат операции.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> EditCustomerAsync(Guid id, CreateOrEditCustomerRequest request)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null)
        {
            return NotFound($"Клиент с Id {id} не найден.");
        }

        // Обновление данных клиента
        customer.FirstName = request.FirstName;
        customer.LastName = request.LastName;
        customer.Email = request.Email;

        // Удаление существующих предпочтений клиента 
        foreach (var customerPreference in customer.CustomerPreferences)
        {
            await _customerPreferencesRepository.DeleteAsync(customerPreference.Id);
        }

        // Добавление новых предпочтений
        foreach (var preferenceId in request.PreferenceIds)
        {
            var newPreference = new CustomerPreference
            {
                Id = Guid.NewGuid(),
                CustomerId = id,
                PreferenceId = preferenceId
            };
            await _customerPreferencesRepository.AddAsync(newPreference);
        }

        return Ok($"Пользователь с Id {id} успешно обновлен.");
    }


    /// <summary>
    /// Удаление клиента вместе с выданными ему промокодами.
    /// </summary>
    /// <param name="id">Id клиента для удаления.</param>
    /// <returns>Возвращает статус 204 No Content в случае успеха.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomerAsync(Guid id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null)
        {
            return NotFound($"Клиент с Id {id} не найден.");
        }

        foreach (var customerPrefs in customer.CustomerPreferences)
        {
            await _customerPreferencesRepository.DeleteAsync(customerPrefs.Id);
        }

        await _customerRepository.DeleteAsync(customer.Id);

        return Ok($"Пользователь с Id {id} успешно удален.");
    }

}