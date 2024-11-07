using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiCareSystemAtHome.Repositories.Reponsitories;

public class ProductRepository : IProductRepository
{
    private readonly KoiCareSystemAtHomeContext _dbContext;
    public ProductRepository(KoiCareSystemAtHomeContext dbContext) 
    {
       _dbContext = dbContext;
    }

    
    public Task<int> AddProductAsync(object Product)
    {
        throw new NotImplementedException();
    }

    

    public Task<bool> DeleteProductAsync(int Product)
    {
        throw new NotImplementedException();
    }

    
    public Task<List<Product>> GetProduct()
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

  
}
