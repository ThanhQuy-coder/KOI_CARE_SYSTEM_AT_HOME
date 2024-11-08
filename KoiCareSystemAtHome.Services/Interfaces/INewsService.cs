using KoiCareSystemAtHome.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KoiCareSystemAtHome.Services.Interfaces
{
    public interface INewsService
    {
        IEnumerable<News> GetAllNews();
        News GetNewsById(int id);
        void AddNews(News news);
        void UpdateNews(News news);
        void DeleteNews(int id);
    }
}

