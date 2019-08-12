namespace BaleLib.Models
{
    public class TextMessage : BaseModel
    {
        public string Text { get; set; }
        public int ReplyToMessageId { get; set; }
    }
}
