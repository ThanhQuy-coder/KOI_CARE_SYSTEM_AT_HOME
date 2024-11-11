using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly KoiCareSystemAtHomeContext _context;

        public NewsRepository(KoiCareSystemAtHomeContext context)
        {
            _context = context;
        }

        public async Task<List<News>> GetAllNewsAsync()
        {
            return await _context.News.ToListAsync();
        }

        public bool DeleteNews(Guid id)
        {
            var news = _context.News.Find(id);
            if (news != null)
            {
                _context.News.Remove(news);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteNews(News news)
        {
            if (news != null)
            {
                _context.News.Remove(news);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool AddNews(News news)
        {
            if (news != null)
            {
                _context.News.Add(news);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateNews(News news)
        {
            if (news != null)
            {
                _context.Entry(news).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<News> GetNewsByIdAsync(Guid id)
        {
            return await _context.News.FindAsync(id);
        }
    }
}


