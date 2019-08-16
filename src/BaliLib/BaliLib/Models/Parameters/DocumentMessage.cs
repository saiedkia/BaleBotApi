namespace BaleLib.Models.Parameters
{
    public class DocumentMessage : BaseInput
    {
        public byte[] Document { get; set; }
        public string Caption { get; set; }
        public string Name { get; set; }
    }
}
