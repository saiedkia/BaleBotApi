namespace BaleLib.Models.Parameters
{
    public class AudioMessage : BaseInput, IFile
    {
        public string Caption { get; set; }
        public string Title { get; set; }
        public byte[] Audio { get; set; }

        public byte[] ReadFile(string filePath)
        {
            Audio = Utils.ToBytes(filePath);
            return Audio;
        }
    }
}
