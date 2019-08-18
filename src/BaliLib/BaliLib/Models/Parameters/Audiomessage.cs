namespace BaleLib.Models.Parameters
{
    public class AudioMessage : BaseInput
    {
        public string Caption { get; set; }
        public string Title { get; set; }
        public byte[] Audio { get; set; }
    }
}
