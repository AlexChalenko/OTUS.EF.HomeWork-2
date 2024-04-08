using Microsoft.AspNetCore.Mvc;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.WebHost.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PreferencesController : ControllerBase
    {
        private readonly IRepository<Preference> _preferenceRepository;

        public PreferencesController(IRepository<Preference> preferenceRepository)
        {
            _preferenceRepository = preferenceRepository;
        }

        /// <summary>
        /// Получить список всех предпочтений
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<PreferenceResponse>> GetPreferencesAsync()
        {
            var allPreferences = await _preferenceRepository.GetAllAsync();
            var response = new List<PreferenceResponse>();
            foreach (var preference in allPreferences)
            {
                response.Add(new PreferenceResponse
                {
                    Id = preference.Id,
                    Name = preference.Name,
                });
            }
            return response;
        }
    }
}
