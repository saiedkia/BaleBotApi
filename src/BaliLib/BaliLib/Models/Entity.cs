namespace BaleLib.Models
{
    public class Entity
    {
        public string Type { get; set; }
        public long Offset { get; set; }
        public long Length { get; set; }
        public string Url { get; set; }
        public From User { get; set; }
    }
}
