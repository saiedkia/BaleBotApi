namespace BaleLib.Models.Parameters
{
    public class VideoMessage : BaseInput, IFile
    {
        public byte[] Video { get; set; }
        public string Caption { get; set; }
        public string Name { get; set; }

        public byte[] ReadFile(string filePath)
        {
            Video = Utils.ToBytes(filePath);
            return Video;
        }
    }
}
