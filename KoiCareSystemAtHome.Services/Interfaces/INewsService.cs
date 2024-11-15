using KoiCareSystemAtHome.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;



namespace KoiCareSystemAtHome.Services.Interfaces
{
    public interface INewsService
    {
        Task<List<News>> GetAllNewsAsync();
        bool DeleteNews(Guid id);
        bool DeleteNews(News news);
        bool AddNews(News news, IFormFile imageFile); // Cập nhật tham số
        bool UpdateNews(News news, IFormFile imageFile); // Cập nhật tham số
        Task<News> GetNewsByIdAsync(Guid id);
        Task<List<News>> SearchNewsAsync(string searchTerm);

    }
}

