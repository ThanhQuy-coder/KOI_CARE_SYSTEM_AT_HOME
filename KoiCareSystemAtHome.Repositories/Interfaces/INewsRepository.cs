using KoiCareSystemAtHome.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories.Interfaces
{
    public interface INewsRepository
    {
        IEnumerable<News> GetAllNews();
        News GetNewsById(int id);
        void AddNews(News news);
        void UpdateNews(News news);
        void DeleteNews(int id);
    }
}

