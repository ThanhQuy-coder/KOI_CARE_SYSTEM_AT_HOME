using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Services.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> _commentsRepository;

        public CommentsService(IRepository<Comment> commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync()
        {
            return await _commentsRepository.GetAllAsync();
        }

        public async Task<Comment> GetCommentByIdAsync(int id)
        {
            return await _commentsRepository.GetByIdAsync(id);
        }

        public async Task AddCommentAsync(Comment comment)
        {
            await _commentsRepository.AddAsync(comment);
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            await _commentsRepository.UpdateAsync(comment);
        }

        public async Task DeleteCommentAsync(int id)
        {
            await _commentsRepository.DeleteAsync(id);
        }
    }

}
