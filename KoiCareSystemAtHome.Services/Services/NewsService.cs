using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiCareSystemAtHome.Services.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _repository;

        public NewsService(INewsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<News>> GetAllNewsAsync()
        {
            return await _repository.GetAllNewsAsync();
        }

        public async Task<News> GetNewsByIdAsync(int id)
        {
            return await _repository.GetNewsByIdAsync(id);
        }

        public bool AddNews(News news)
        {
            return _repository.AddNews(news);
        }

        public bool UpdateNews(News news)
        {
            return _repository.UpdateNews(news);
        }

        public bool DeleteNews(int id)
        {
            return _repository.DeleteNews(id);
        }

        public bool DeleteNews(News news)
        {
            return _repository.DeleteNews(news);
        }
    }
}











