using Microsoft.AspNetCore.Authorization;

namespace VietnamSnackis.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public string CommentedByUser { get; set; }
        public DateTime DateCommented { get; set; }
        //public Post Post { get; set; }
    }
}
