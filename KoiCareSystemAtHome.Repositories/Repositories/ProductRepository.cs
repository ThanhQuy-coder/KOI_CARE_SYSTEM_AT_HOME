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


    public bool AddProduct(Product product)
    {
        try
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            return true;
        }
        catch (Exception ex)
        {
           
            return false;
        }
    }

    public bool DeleteProduct(Guid id)
    {
        try
        {
            var objDel = _dbContext.Products.FirstOrDefault(p => p.ProductId.Equals(id));
            if (objDel != null)
            {
                _dbContext.Products.Remove(objDel);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi, không thể xóa sản phẩm bằng ID: {ex.Message}");
            return false;
        }
    }

    public bool DeleteProduct(Product product)
    {
        try
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi, không thể xóa sản phẩm: {ex.Message}");
            return false;
        }
    }



    public async Task<List<Product>> GetAllProducts()
    {
        return await _dbContext.Products
                .Include(k => k.User) // Sử dụng Include để nạp đối tượng User
                .ToListAsync();
    }

    public async Task<Product> GetProductById(Guid id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId.Equals(id));
    }

    

    public bool UpdateProduct(Product product)
    {
        try
        {
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi, không thể cập nhật sản phẩm: {ex.Message}");
            return false;
        }
    }



}
