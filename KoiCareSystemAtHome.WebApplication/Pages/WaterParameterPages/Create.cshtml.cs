using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.WaterParameterPages
{
    public class CreateModel : PageModel
    {
        private readonly IWaterParameterService _service;

        public CreateModel(IWaterParameterService service)
        {
            _service = service;
        }

        [BindProperty]
        public WaterParameter WaterParameter { get; set; } = default!;
        public List<string> WarningMessages { get; set; } = new List<string>();

        // Nhận PondId từ query string trong URL
        public IActionResult OnGet(Guid pondId)
        {
            WaterParameter = new WaterParameter { PondId = pondId };
            return Page();
        }

        public IActionResult OnPost()
        {
            if (WaterParameter.PondId == Guid.Empty)
            {
                ModelState.AddModelError(string.Empty, "PondId is required.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Kiểm tra giới hạn và thêm cảnh báo nếu cần
            if (WaterParameter.Temperature < 10 || WaterParameter.Temperature > 30)
            {
                WarningMessages.Add("Nhiệt độ nằm ngoài giới hạn ổn định của hồ.");
            }
            if (WaterParameter.SaltLevel < 0.1 || WaterParameter.SaltLevel > 0.5)
            {
                WarningMessages.Add("Mức muối nằm ngoài giới hạn ổn định của hồ.");
            }
            if (WaterParameter.PH < 6.5 || WaterParameter.PH > 8.5)
            {
                WarningMessages.Add("PH nằm ngoài giới hạn ổn định của hồ.");
            }
            if (WaterParameter.Oxygen < 5 || WaterParameter.Oxygen > 12)
            {
                WarningMessages.Add("Oxy nằm ngoài giới hạn ổn định của hồ.");
            }
            if (WaterParameter.Nitrie < 0 || WaterParameter.Nitrie > 0.2)
            {
                WarningMessages.Add("Nitrit nằm ngoài giới hạn ổn định của hồ.");
            }
            if (WaterParameter.Nitrate < 0 || WaterParameter.Nitrate > 50)
            {
                WarningMessages.Add("Nitrat nằm ngoài giới hạn ổn định của hồ.");
            }
            if (WaterParameter.Phospate < 0 || WaterParameter.Phospate > 1)
            {
                WarningMessages.Add("Phosphat nằm ngoài giới hạn ổn định của hồ.");
            }

            // Lưu các cảnh báo vào TempData nếu có
            if (WarningMessages.Any())
            {
                TempData["WarningMessages"] = string.Join(";", WarningMessages);
            }
            else
            {
                // Thông báo "Thông số nước đã ổn cho hồ" nếu không có cảnh báo
                TempData["SuccessMessage"] = "Thông số nước đã ổn cho hồ.";
                TempData.Remove("WarningMessages");
            }

            var result = _service.AddWaterParameter(WaterParameter);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error adding WaterParameter.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
    