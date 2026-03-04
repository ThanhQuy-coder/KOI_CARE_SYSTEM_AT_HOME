using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.WaterParameterPages
{
    public class EditModel : PageModel
    {
        private readonly IWaterParameterService _service;

        public EditModel(IWaterParameterService service)
        {
            _service = service;
        }

        [BindProperty]
        public WaterParameter WaterParameter { get; set; } = default!;
        public List<string> WarningMessages { get; set; } = new List<string>();

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterparameter = await _service.GetWaterParameterById((Guid)id);
            if (waterparameter == null)
            {
                return NotFound();
            }
            else
            {
                WaterParameter = waterparameter;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Đảm bảo WarningMessages rỗng ở mỗi lần kiểm tra
            WarningMessages.Clear();

            // Kiểm tra giới hạn và thêm cảnh báo nếu cần
            if (WaterParameter.Temperature < 10 || WaterParameter.Temperature > 30)
            {
                WarningMessages.Add("Nhiệt độ nằm ngoài giới hạn ổn định của hồ.");
            }
            if (WaterParameter.SaltLevel < (Decimal)0.1 || WaterParameter.SaltLevel > (Decimal)0.5)
            {
                WarningMessages.Add("Mức muối nằm ngoài giới hạn ổn định của hồ.");
            }
            if (WaterParameter.Ph < (Decimal)6.5 || WaterParameter.Ph > (Decimal)8.5)
            {
                WarningMessages.Add("PH nằm ngoài giới hạn ổn định của hồ.");
            }
            if (WaterParameter.Oxygen < 5 || WaterParameter.Oxygen > 12)
            {
                WarningMessages.Add("Oxy nằm ngoài giới hạn ổn định của hồ.");
            }
            if (WaterParameter.Nitrite < 0 || WaterParameter.Nitrite > (Decimal)0.2)
            {
                WarningMessages.Add("Nitrit nằm ngoài giới hạn ổn định của hồ.");
            }
            if (WaterParameter.Nitrate < 0 || WaterParameter.Nitrate > 50)
            {
                WarningMessages.Add("Nitrat nằm ngoài giới hạn ổn định của hồ.");
            }
            if (WaterParameter.Phosphate < 0 || WaterParameter.Phosphate > 1)
            {
                WarningMessages.Add("Phosphat nằm ngoài giới hạn ổn định của hồ.");
            }

            // Nếu có cảnh báo, lưu chúng vào TempData
            if (WarningMessages.Any())
            {
                TempData["WarningMessages"] = string.Join(";", WarningMessages);
                TempData.Remove("SuccessMessage");
            }
            else
            {
                TempData["SuccessMessage"] = "Thông số nước đã ổn cho hồ.";
                TempData.Remove("WarningMessages"); // Giữ lại cho các lần truy cập tiếp theo
            }

            var existingWaterParameter = await _service.GetWaterParameterById(WaterParameter.ParameterId);
            if (existingWaterParameter == null)
            {
                return NotFound();
            }

            // Cập nhật các trường cần thiết
            existingWaterParameter.Temperature = WaterParameter.Temperature;
            existingWaterParameter.SaltLevel = WaterParameter.SaltLevel;
            existingWaterParameter.Ph = WaterParameter.Ph;
            existingWaterParameter.Oxygen = WaterParameter.Oxygen;
            existingWaterParameter.Nitrite = WaterParameter.Nitrite;
            existingWaterParameter.Nitrate = WaterParameter.Nitrate;
            existingWaterParameter.Phosphate = WaterParameter.Phosphate;
            existingWaterParameter.MeasurementTime = WaterParameter.MeasurementTime;


            // Tiến hành cập nhật WaterParameter

            bool result = _service.UppWaterParameter(existingWaterParameter);
            if (!result)
            {
                throw new Exception("Lỗi cập nhật thông số nước.");
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> WaterParameterExists(Guid id)
        {
            var WaterParameter = await _service.GetWaterParameterById(id);
            return WaterParameter != null;
        }
    }
}
