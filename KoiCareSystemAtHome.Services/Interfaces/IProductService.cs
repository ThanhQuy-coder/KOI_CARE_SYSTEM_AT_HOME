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
        Task<int> AddProductAsync(object Product);
        Task<bool> DeleteProductAsync(int Product);
        Task<int> UpdateProductAsync(Product product);
        Task SaveChangesAsync();
        Task<List<Product>> Product();
        Task<List<Product>> GetProductAsync();
    }
}
