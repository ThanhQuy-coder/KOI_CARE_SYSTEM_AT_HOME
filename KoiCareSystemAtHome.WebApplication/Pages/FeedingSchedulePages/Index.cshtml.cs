using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.FeedingSchedulePages
{
    public class IndexModel : PageModel
    {
        private readonly IFeedingScheduleService _service;

        public IndexModel(IFeedingScheduleService service)
        {
            _service = service;
        }

        public IList<FeedingSchedule> FeedingSchedule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            FeedingSchedule = await _service.GetAllFeedingSchedules();
        }
    }
}
