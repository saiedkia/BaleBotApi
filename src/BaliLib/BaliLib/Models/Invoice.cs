namespace BaleLib.Models
{
    public class Invoice
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string StartParameter { get; set; }
        public string Currency { get; set; }
        public long TotalAmount { get; set; }
    }
}
