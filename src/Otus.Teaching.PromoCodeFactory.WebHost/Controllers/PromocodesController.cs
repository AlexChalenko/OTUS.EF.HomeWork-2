using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.WebHost.Models;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Промокоды
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PromocodesController : ControllerBase
    {
        private readonly IRepository<PromoCode> _promocodeRepository;
        private readonly IRepository<CustomerPreference> _customerPreferencesRepository;

        public PromocodesController(IRepository<PromoCode> promocodeRepository, IRepository<CustomerPreference> customerPreferenceRepository)
        {
            _promocodeRepository = promocodeRepository;
            _customerPreferencesRepository = customerPreferenceRepository;
        }
        /// <summary>
        /// Получить все промокоды
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<PromoCodeShortResponse>>> GetPromocodesAsync()
        {
            var allPromoCedes = await _promocodeRepository.GetAllAsync();
            var response = new List<PromoCodeShortResponse>();
            foreach (var promoCode in allPromoCedes)
            {
                response.Add(new PromoCodeShortResponse()
                {
                    Id = promoCode.Id,
                    Code = promoCode.Code,
                    ServiceInfo = promoCode.ServiceInfo,
                    BeginDate = promoCode.BeginDate.ToString(),
                    EndDate = promoCode.EndDate.ToString(),
                    PartnerName = promoCode.PartnerManager.FullName
                });
            }

            return response;
        }

        /// <summary>
        /// Создать промокод и выдать его клиентам с указанным предпочтением
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeRequest request)
        {
            try
            {
                var names = request.PartnerName.Split(' ');
                var newPromoCode = new PromoCode()
                {
                    Code = request.PromoCode,
                    ServiceInfo = request.ServiceInfo,
                    BeginDate = DateTime.Today,
                    EndDate = DateTime.Today.AddDays(30), //?
                    PartnerManagerId = Guid.Parse(request.PartnerName),
                    PreferenceId = Guid.Parse(request.Preference),
                };

                var allCustomerPreferences = await _customerPreferencesRepository.GetAllAsync();
                var allCustomersWithPreferences = allCustomerPreferences.Where(cp => cp.PreferenceId.Equals(newPromoCode.PreferenceId)).Select(c => c.Customer);

                if (allCustomersWithPreferences.FirstOrDefault() is { } customer)
                {
                    newPromoCode.CustomerId = customer.Id;
                    await _promocodeRepository.AddAsync(newPromoCode);
                }
                else
                {
                    return BadRequest("No customers with this preference");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}