using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;


namespace KoiCareSystemAtHome.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();  // Lấy tất cả sản phẩm

        bool AddProduct(Product product);  // Thêm sản phẩm

        bool DeleteProduct(Guid id);  // Xóa sản phẩm theo ID

        bool DeleteProduct(Product product);  // Xóa sản phẩm theo đối tượng Product

        Task<Product> GetProductById(Guid id);  // Lấy sản phẩm theo ID

        bool UpdateProduct(Product product);  // Cập nhật sản phẩm

        
    }
}
