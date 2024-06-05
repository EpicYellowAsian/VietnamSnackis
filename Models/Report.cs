namespace VietnamSnackis.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string ByUser { get; set; }
        public string PostId { get; set; }
        public string Text { get; set; }
        public DateTime DateReported { get; set; } 
    }
}
