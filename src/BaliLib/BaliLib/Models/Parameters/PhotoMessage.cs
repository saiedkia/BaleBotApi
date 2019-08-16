namespace BaleLib.Models.Parameters
{
    public class PhotoMessage : BaseInput
    {
        public byte[] Photo { get; set; }
        public string Caption { get; set; }
    }
}
