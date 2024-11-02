using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories.Entities
{
    public class Category
    {
        public int CategoryId { get; set; } // ID của danh mục
        public string Name { get; set; } // Tên danh mục
        public List<Article> Articles { get; set; } // Danh sách bài viết thuộc danh mục
    }
}
