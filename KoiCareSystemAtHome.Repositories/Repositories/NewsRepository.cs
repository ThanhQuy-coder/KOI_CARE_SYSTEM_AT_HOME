using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KoiCareSystemAtHome.Repositories.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly KoiCareSystemAtHomeContext _context;

        public NewsRepository(KoiCareSystemAtHomeContext context)
        {
            _context = context;
        }

        public IEnumerable<News> GetAllNews()
        {
            return _context.News.ToList();
        }

        public News GetNewsById(int id)
        {
            return _context.News.Find(id);
        }

        public void AddNews(News news)
        {
            _context.News.Add(news);
            _context.SaveChanges();
        }

        public void UpdateNews(News news)
        {
            _context.Entry(news).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteNews(int id)
        {
            var news = _context.News.Find(id);
            if (news != null)
            {
                _context.News.Remove(news);
                _context.SaveChanges();
            }
        }
    }
}


