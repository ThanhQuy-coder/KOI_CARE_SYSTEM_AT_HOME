using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.KoiFishPage
{
    
    public class IndexModel : PageModel
    {
        private readonly IKoiFishService _service;
        public IndexModel(IKoiFishService service)
        {
            _service = service;
        }

        public IList<KoiFish> KoiFish { get;set; } = default!;

        public async Task OnGetAsync()
        {
            KoiFish = await _service.GetAllKoiFish();
        }
    }
}
