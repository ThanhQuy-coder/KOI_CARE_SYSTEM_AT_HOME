using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Services.Services
{
    public class ArticlesService : IArticlesService
    {
        private readonly IRepository<Article> _articlesRepository;

        public ArticlesService(IRepository<Article> articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public async Task<IEnumerable<Article>> GetAllArticlesAsync()
        {
            return await _articlesRepository.GetAllAsync();
        }

        public async Task<Article> GetArticleByIdAsync(int id)
        {
            return await _articlesRepository.GetByIdAsync(id);
        }

        public async Task AddArticleAsync(Article article)
        {
            await _articlesRepository.AddAsync(article);
        }

        public async Task UpdateArticleAsync(Article article)
        {
            await _articlesRepository.UpdateAsync(article);
        }

        public async Task DeleteArticleAsync(int id)
        {
            await _articlesRepository.DeleteAsync(id);
        }
    }

}
