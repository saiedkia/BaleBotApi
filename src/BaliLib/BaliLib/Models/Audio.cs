namespace BaleLib.Models
{
    public class Audio
    {
        public string FileId { get; set; }
        public long Duration { get; set; }
        public string Performer { get; set; }
        public string Title { get; set; }
        public string MimeType { get; set; }
        public long FileSize { get; set; }
    }
}
