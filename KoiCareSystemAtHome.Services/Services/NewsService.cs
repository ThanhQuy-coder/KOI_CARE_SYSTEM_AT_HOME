using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace KoiCareSystemAtHome.Services.Services
{
    public class NewsService : INewsService
    {
        private readonly KoiCareSystemAtHomeContext _context;

        public NewsService(KoiCareSystemAtHomeContext context)
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





     
   


