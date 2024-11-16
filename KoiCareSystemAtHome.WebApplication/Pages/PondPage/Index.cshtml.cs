﻿using KoiCareSystemAtHome.Services.Interfaces;
using KoiCareSystemAtHome.Repositories.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KoiCareSystemAtHome.WebApplication.Pages.PondPage
{
    public class IndexModel : PageModel
    {
        private readonly IPondService _service;

        public IndexModel(IPondService service)
        {
            _service = service;
        }

        public List<Pond> Pond { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public string OwnerName { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Pond = await _service.GetAllPond();

            // Tìm kiếm theo tên hồ hoặc độ sâu
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Pond = Pond.Where(p => p.NamePond.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                                       p.Depth.ToString().Contains(SearchTerm)).ToList();
            }

            // Tìm kiếm theo tên chủ hồ
            if (!string.IsNullOrEmpty(OwnerName))
            {
                Pond = Pond.Where(p => p.User.FullName.Contains(OwnerName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return Page();
        }
    }
}
