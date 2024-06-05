namespace VietnamSnackis.Models
{
    public class PrivateMessage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }
        public bool Flagged { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; } 
    }
}
