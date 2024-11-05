using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories.Entities
{
    public class Comment
    {
        public int CommentId { get; set; } // ID của bình luận
        public string Content { get; set; } // Nội dung bình luận
        public DateTime CreatedDate { get; set; } // Ngày tạo bình luận
        public int ArticleId { get; set; } // ID của bài viết
        public Article Article { get; set; } // Đối tượng bài viết
    }
}
