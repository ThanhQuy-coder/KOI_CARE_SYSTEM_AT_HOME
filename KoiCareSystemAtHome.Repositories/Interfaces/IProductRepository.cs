using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;

namespace KoiCareSystemAtHome.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<int> AddProductAsync(object Product);
        Task<bool> DeleteProductAsync(int Product);
        Task<int> UpdateProductAsync(Product product);
        Task SaveChangesAsync();
        Task<List<Product>> GetProduct();
    }
}
