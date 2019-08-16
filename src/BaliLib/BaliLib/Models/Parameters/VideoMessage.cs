namespace BaleLib.Models.Parameters
{
    public class VideoMessage : BaseInput
    {
        public byte[] Video { get; set; }
        public string Caption { get; set; }
        public string Name { get; set; }
    }
}
