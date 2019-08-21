namespace BaleLib.Models.Parameters
{
    public class DocumentMessage : BaseInput, IFile
    {
        public byte[] Document { get; set; }
        public string Caption { get; set; }
        public string Name { get; set; }

        public byte[] ReadFile(string filePath)
        {
            Document = Utils.ToBytes(filePath);
            return Document;
        }
    }
}
