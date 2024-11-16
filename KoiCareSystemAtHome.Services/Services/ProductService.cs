using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public bool AddProduct(Product product)
        {
            return _repository.AddProduct(product);
        }

        public bool DeleteProduct(Guid id)
        {
            return _repository.DeleteProduct(id);
        }

        public bool DeleteProduct(Product product)
        {
            return _repository.DeleteProduct(product);
        }

        

        public Task<List<Product>> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

        public Task<Product> GetProductById(Guid id)
        {
            return _repository.GetProductById(id);
        }


        public bool UpdateProduct(Product product)
        {
            return _repository.UpdateProduct(product);
        }
        public async Task<Product> InitializeProduct(Guid userId)
        {
            // Khởi tạo đối tượng KoiFish với PondId được truyền vào
            return await Task.FromResult(new Product { UserId = userId });
        }
        public async Task<List<Product>> SearchProductAsync(string searchTerm)
        {
            return await _repository.SearchProductAsync(searchTerm);

        }

    }
}
