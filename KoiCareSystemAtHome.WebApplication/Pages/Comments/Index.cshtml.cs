using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystemAtHome.WebApplication.Pages.Comments
{
    public class CommentsIndexModel : PageModel
    {
        private readonly ICommentsService _commentsService;

        public CommentsIndexModel(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        public IList<Comment> Comments { get; set; }

        public async Task OnGetAsync()
        {
            Comments = (await _commentsService.GetAllCommentsAsync()).ToList();
        }
    }
}
