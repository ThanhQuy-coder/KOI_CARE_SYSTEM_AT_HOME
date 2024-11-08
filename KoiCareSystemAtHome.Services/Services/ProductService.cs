using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
namespace KoiCareSystemAtHome.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly KoiCareSystemAtHomeContext _repository;

        public string ImageFileName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ProductService(KoiCareSystemAtHomeContext repository)
        {
            _repository = repository;
        }


        public Task<int> AddProductAsync(object Product)
        {
            throw new NotImplementedException();
        }

        

        public Task<bool> DeleteProductAsync(int Product)
        {
            throw new NotImplementedException();
        }

       

        public Task<List<Product>> GetProductAsync()
        {
            throw new NotImplementedException();
        }

        
        public Task<List<Product>> Product()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

       

        public Task<int> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            if (imageFile != null)
            {
                var filePath = Path.Combine("wwwroot/uploads", imageFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                return "/uploads/" + imageFile.FileName;
            }
            return null;
        }

    }
}
