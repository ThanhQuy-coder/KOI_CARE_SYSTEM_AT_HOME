using KoiCareSystemAtHome.Services.Interfaces;
using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KoiCareSystemAtHome.WebApplication.Pages.KoiFishPage
{
    public class IndexModel : PageModel
    {
        private readonly IKoiFishService _service;

        public IndexModel(IKoiFishService service)
        {
            _service = service;
        }

        public List<KoiFish> KoiFish { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Breed { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PondName { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            KoiFish = await _service.GetAllKoiFish();

            // Tìm kiếm theo tên cá hoặc giá
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                KoiFish = KoiFish.Where(kf => kf.NameFish.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                                               kf.Price.ToString().Contains(SearchTerm)).ToList();
            }

            // Tìm kiếm theo giống cá
            if (!string.IsNullOrEmpty(Breed))
            {
                KoiFish = KoiFish.Where(kf => kf.Breed.Contains(Breed, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Tìm kiếm theo tên hồ
            if (!string.IsNullOrEmpty(PondName))
            {
                KoiFish = KoiFish.Where(kf => kf.Pond.NamePond.Contains(PondName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return Page();
        }
    }
}
