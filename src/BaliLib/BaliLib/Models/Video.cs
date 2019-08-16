namespace BaleLib.Models
{
    public class Video
    {
        public string FileId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Duration { get; set; }
        public string MimeType { get; set; }
        public long FileSize { get; set; }
    }
}
