using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.WebApplication.Pages.NewsPage
{
    public class CreateModel : PageModel
    {
        private readonly INewsService _newsService;

        public CreateModel(INewsService newsService)
        {
            _newsService = newsService;
        }

        [BindProperty]
        public News News { get; set; } = default!;

        // Thêm thuộc tính ImageFile để nhận file ảnh từ form
        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra xem News.PostId có hợp lệ không
            //if (News.PostId == Guid.Empty)
            //{
            //    ModelState.AddModelError(string.Empty, "Chỉ được tạo bài viết từ trang Category!");
            //    return Page();
            //}

            //// Kiểm tra tính hợp lệ của Model
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            // Lưu ảnh và thiết lập đường dẫn cho ImageUrl trong News
            if (ImageFile != null)
            {
                var fileName = Path.GetFileName(ImageFile.FileName);
                var filePath = Path.Combine("wwwroot/images", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                }

                News.ImageUrl = $"/uploads/{fileName}";
            }

            // Gọi phương thức AddNews để thêm News và ImageFile
            bool result = _newsService.AddNews(News, ImageFile);

            // Nếu không thêm được thì báo lỗi
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error adding news. Please try again.");
                return Page();
            }

            // Nếu thành công, chuyển hướng về trang Index
            return RedirectToPage("./Index");
        }
    }
}

