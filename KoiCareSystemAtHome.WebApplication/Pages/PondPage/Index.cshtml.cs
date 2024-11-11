using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.PondPage
{

    public class IndexModel : PageModel
    {
        private readonly IPondService _service;
        public IndexModel(IPondService service)
        {
            _service = service;
        }

        public IList<Pond> Pond { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Pond = await _service.GetAllPond();
        }
    }
}