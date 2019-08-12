using System.Collections.Generic;

namespace BaleLib.Models
{
    public class Chat
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool AllMembersAreAdministrator { get; set; }
        public string Description { get; set; }
        public string InviteLink { get; set; }
        public List<long> PinnedMessage { get; set; }
        public string StickerSetName { get; set; }
        public bool CanSetStickerSet { get; set; }
    }
}
