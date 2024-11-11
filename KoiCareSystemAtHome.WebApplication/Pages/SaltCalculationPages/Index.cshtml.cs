﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;

namespace KoiCareSystemAtHome.WebApplication.Pages.SaltCalculationPages
{
    public class IndexModel : PageModel
    {
        private readonly KoiCareSystemAtHome.Repositories.Entities.KoiCareSystemAtHomeContext _context;

        public IndexModel(KoiCareSystemAtHome.Repositories.Entities.KoiCareSystemAtHomeContext context)
        {
            _context = context;
        }

        public IList<SaltCalculation> SaltCalculation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            SaltCalculation = await _context.SaltCalculations
                .Include(s => s.Pond).ToListAsync();
        }
    }
}
