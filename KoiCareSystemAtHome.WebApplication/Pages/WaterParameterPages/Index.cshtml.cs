using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.WaterParameterPages
{
    public class IndexModel : PageModel
    {
        private readonly IWaterParameterService _service;

        public IndexModel(IWaterParameterService service)
        {
            _service = service;
        }

        public IList<WaterParameter> WaterParameter { get;set; } = default!;

        public async Task OnGetAsync()
        {
            WaterParameter = await _service.GetAllWaterParameter();
        }

    }
}
