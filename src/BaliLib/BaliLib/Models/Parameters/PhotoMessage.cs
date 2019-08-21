namespace BaleLib.Models.Parameters
{
    public class PhotoMessage : BaseInput, IFile
    {
        public byte[] Photo { get; set; }
        public string Caption { get; set; }
        public ReplyKeyboard ReplyMarkup { get; set; }

        public byte[] ReadFile(string filePath)
        {
            Photo = Utils.ToBytes(filePath);
            return Photo;
        }
    }
}
