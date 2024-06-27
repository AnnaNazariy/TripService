namespace BlazorApp1.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
    }
}
