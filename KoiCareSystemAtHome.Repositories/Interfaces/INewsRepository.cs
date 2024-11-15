using KoiCareSystemAtHome.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories.Interfaces
{
    public interface INewsRepository
    {
        Task<List<News>> GetAllNewsAsync();
        bool DeleteNews(Guid id);
        bool DeleteNews(News news);
        bool AddNews(News news);
        bool UpdateNews(News news);
        Task<News> GetNewsByIdAsync(Guid id);
        Task<List<News>> SearchNewsAsync(string searchTerm);


    }
}

