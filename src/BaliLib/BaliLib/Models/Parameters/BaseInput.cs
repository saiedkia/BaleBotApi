namespace BaleLib.Models.Parameters
{
    public class BaseInput
    {
        public long ChatId { get; set; }
        public long? ReplyToMessageId { get; set; }

        public BaseInput(long chatId, long? replyToMessageId = null)
        {
            ChatId = chatId;
            ReplyToMessageId = replyToMessageId;
        }

        public BaseInput()
        {
        }

        public BaseInput(long chatId)
        {
            ChatId = chatId;
        }
    }
}
