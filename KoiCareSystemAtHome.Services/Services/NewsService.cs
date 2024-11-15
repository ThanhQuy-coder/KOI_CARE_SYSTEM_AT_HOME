using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

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
            var newsList = await _repository.GetAllNewsAsync();

            // Đảm bảo trả về danh sách không chứa phần tử null
            return newsList.Where(n => n != null).ToList();
        }


        public async Task<News> GetNewsByIdAsync(Guid id)
        {
            return await _repository.GetNewsByIdAsync(id);
        }

        public bool AddNews(News news, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine("wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                news.ImageUrl = "/images/" + fileName;
            }

            return _repository.AddNews(news);
        }

        public bool UpdateNews(News news, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine("wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                news.ImageUrl = "/images/" + fileName;
            }

            return _repository.UpdateNews(news);
        }

        public bool DeleteNews(Guid id)
        {
            return _repository.DeleteNews(id);
        }

        public bool DeleteNews(News news)
        {
            return _repository.DeleteNews(news);
        }

        public async Task<List<News>> SearchNewsAsync(string searchTerm)
        {
            return await _repository.SearchNewsAsync(searchTerm);
        }
    }
}











