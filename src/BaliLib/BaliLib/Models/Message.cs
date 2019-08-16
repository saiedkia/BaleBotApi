using System.Collections.Generic;

namespace BaleLib.Models
{
    public class Message
    {
        public long MessageId { get; set; }
        public From From { get; set; }
        public long Date { get; set; }
        public Chat Chat { get; set; }
        public string Text { get; set; }

        public List<Photo> Photo { get; set; }
        public string Caption { get; set; }

        public Chat ForwardFromChat { get; set; }
        public From ForwardFrom { get; set; }
        public long ForwardFromMessageId { get; set; }
        public long ForwardDate { get; set; }
    }
}