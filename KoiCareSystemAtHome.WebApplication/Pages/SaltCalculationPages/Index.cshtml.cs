using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.SaltCalculationPages
{
    public class IndexModel : PageModel
    {
        private readonly ISaltCalculationService _service;

        public IndexModel(ISaltCalculationService service)
        {
            _service = service;
        }

        public IList<SaltCalculation> SaltCalculation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            SaltCalculation = await _service.GetAllSaltCalculation();
        }
    }
}
