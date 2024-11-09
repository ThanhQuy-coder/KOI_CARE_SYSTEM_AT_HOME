using KoiCareSystemAtHome.Repositories.Entities;

namespace KoiCareSystemAtHome.Services.Interfaces
{
    public interface INewsService
    {
        Task<List<News>> GetAllNewsAsync();
        bool DeleteNews(int id);
        bool DeleteNews(News news);
        bool AddNews(News news);
        bool UpdateNews(News news);
        Task<News> GetNewsByIdAsync(int id);
    }
}

