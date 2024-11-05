using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories.Entities
{
    public class Article
    {
        public int ArticleId { get; set; } // ID của bài viết
        public string Title { get; set; } // Tiêu đề bài viết
        public string Content { get; set; } // Nội dung bài viết
        public DateTime PublishDate { get; set; } // Ngày xuất bản
        public int CategoryId { get; set; } // ID của danh mục
        public Category Category { get; set; } // Đối tượng danh mục
        public List<Comment> Comments { get; set; } // Danh sách bình luận
    }
}