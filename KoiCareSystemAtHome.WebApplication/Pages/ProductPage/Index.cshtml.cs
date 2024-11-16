using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.WebApplication.Pages.ProductPage
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _service;

        public IndexModel(IProductService service)
        {
            _service = service;
        }

        public List<Product> Product { get; set; } = new(); // Danh sách sản phẩm
        public List<Product> CartItems { get; set; } = new(); // Danh sách giỏ hàng

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } // Tìm kiếm theo tên sản phẩm hoặc giá

        [BindProperty(SupportsGet = true)]
        public string ProductType { get; set; } // Tìm kiếm theo loại sản phẩm

        public async Task<IActionResult> OnGetAsync()
        {
            // Lấy UserId từ Session
            var userId = HttpContext.Session.GetString("UserId");

            // Kiểm tra nếu không có UserId trong Session (nghĩa là chưa đăng nhập)
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToPage("/LoginPage/Index");
            }

            // Lấy danh sách sản phẩm
            Product = await _service.GetAllProducts();

            // Lấy danh sách giỏ hàng từ Session
            CartItems = GetCart();

            // Tìm kiếm theo tên sản phẩm hoặc giá
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Product = Product.Where(p => p.ProductName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                                             p.Price.ToString().Contains(SearchTerm)).ToList();
            }

            // Tìm kiếm theo loại sản phẩm
            if (!string.IsNullOrEmpty(ProductType))
            {
                Product = Product.Where(p => p.ProductType.Contains(ProductType, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return Page();
        }

        public IActionResult OnPostAddToCart(string productName)
        {
            // Lấy danh sách đơn hàng từ Session
            var orderList = HttpContext.Session.GetString("OrderList");
            var orders = string.IsNullOrEmpty(orderList)
                ? new List<string>()
                : JsonConvert.DeserializeObject<List<string>>(orderList);

            // Thêm sản phẩm vào danh sách đơn hàng
            orders.Add(productName);

            // Lưu lại danh sách vào Session
            HttpContext.Session.SetString("OrderList", JsonConvert.SerializeObject(orders));

            TempData["Message"] = $"Product '{productName}' đã được thêm vào giỏ hàng!";
            return RedirectToPage("./Index");
        }

        public List<string> GetOrders()
        {
            // Lấy danh sách đơn hàng từ Session
            var orderList = HttpContext.Session.GetString("OrderList");
            return string.IsNullOrEmpty(orderList)
                ? new List<string>()
                : JsonConvert.DeserializeObject<List<string>>(orderList);
        }


        public List<Product> GetCart()
        {
            // Lấy danh sách giỏ hàng từ Session
            var cartJson = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cartJson))
            {
                return new List<Product>();
            }

            try
            {
                return JsonConvert.DeserializeObject<List<Product>>(cartJson) ?? new List<Product>();
            }
            catch
            {
                // Nếu dữ liệu không hợp lệ, trả về giỏ hàng trống
                return new List<Product>();
            }
        }
        public IActionResult OnPostRemoveFromCart(string productName)
        {
            // Lấy danh sách giỏ hàng từ Session
            var orderList = HttpContext.Session.GetString("OrderList");
            var orders = string.IsNullOrEmpty(orderList)
                ? new List<string>()
                : JsonConvert.DeserializeObject<List<string>>(orderList);

            // Xóa sản phẩm khỏi danh sách nếu tồn tại
            if (orders.Contains(productName))
            {
                orders.Remove(productName);

                // Cập nhật lại giỏ hàng trong Session
                HttpContext.Session.SetString("OrderList", JsonConvert.SerializeObject(orders));

                TempData["Message"] = $"Sản phẩm '{productName}' đã được xóa khỏi giỏ hàng!";
            }
            else
            {
                TempData["Error"] = $"Không tìm thấy sản phẩm '{productName}' trong giỏ hàng!";
            }

            return RedirectToPage("./Index");
        }

        public IActionResult OnPostCheckout()
        {
            // Lấy danh sách giỏ hàng từ Session
            var orderList = HttpContext.Session.GetString("OrderList");
            var orders = string.IsNullOrEmpty(orderList)
                ? new List<string>()
                : JsonConvert.DeserializeObject<List<string>>(orderList);

            // Kiểm tra giỏ hàng trống
            if (orders.Count == 0)
            {
                TempData["Error"] = "Giỏ hàng của bạn đang trống!";
                return RedirectToPage("./Index");
            }

            // Xử lý thanh toán (giả lập)
            // Ví dụ: chuyển danh sách đơn hàng vào cơ sở dữ liệu hoặc gửi email xác nhận.
            TempData["Message"] = $"Thanh toán thành công! Tổng số sản phẩm: {orders.Count}";

            // Xóa giỏ hàng sau khi thanh toán
            HttpContext.Session.Remove("OrderList");

            return RedirectToPage("./Index");
        }
    }
}
