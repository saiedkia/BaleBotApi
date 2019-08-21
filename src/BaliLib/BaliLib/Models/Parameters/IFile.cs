namespace BaleLib.Models.Parameters
{
    public interface IFile
    {
        byte[] ReadFile(string filePath);
    }
}
