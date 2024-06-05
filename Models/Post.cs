using Microsoft.AspNetCore.Identity;
using VietnamSnackis.Areas.Identity.Data;

namespace VietnamSnackis.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Header { get; set; }
        public string Content { get; set; }
        public DateTime PostCreated { get; set; }
        public List<Comment> Comments { get; set; }
        public string? Image { get; set; }
        //public Category Category { get; set; }
        public int? CategoryId { get; set; }
        //public SubCategory SubCategory { get; set; }
        public int SubCategoryId { get; set; }
        public string UserId { get; set; }
        public VietnamSnackisUser? User { get; set; }
    }
}

