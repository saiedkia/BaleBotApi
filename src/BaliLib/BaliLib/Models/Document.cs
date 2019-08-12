namespace BaleLib.Models
{
    public class Document
    {
        public string FileId { get; set; }
        public Thumb Thumb { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public long FileSize { get; set; }
    }
}
