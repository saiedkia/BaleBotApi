using System.Collections.Generic;

namespace BaleLib.Models
{
    public class Result
    {
        public long MessageId { get; set; }
        public From From { get; set; }
        public long Date { get; set; }
        public Chat Chat { get; set; }
        public From ForwardFrom { get; set; }
        public Chat ForwardFromChat { get; set; }
        public long ForwardedFromMessageId { get; set; }
        public long ForwardDate { get; set; }
        public List<string> ReplyToMessage { get; set; }
        public long EditDate { get; set; }
        public string Text { get; set; }
        public List<Entity> Entities { get; set; }
        public List<Entity> CaptionEntities { get; set; }
        public Audio Audio { get; set; }
        public Document Document { get; set; }
        public List<Photo> Photo { get; set; }
        public string Caption { get; set; }
        public Contact Contact { get; set; }
        public Location Location { get; set; }
        public List<From> NewChatMembers { get; set; }
        public From LeftChatMember { get; set; }
        public string NewChatTitle { get; set; }
        public List<Photo> NewChatPhoto { get; set; }
        public bool DeleteChatPhoto { get; set; }
        public bool GroupChatCreated { get; set; }
        public bool SupergroupChatCreated { get; set; }
        public bool ChannelChatCreated { get; set; }
        public List<string> PinnedMessage { get; set; }
        public Invoice Invoice { get; set; }
        public Payment SuccessfulPayment { get; set; }
    }
}
