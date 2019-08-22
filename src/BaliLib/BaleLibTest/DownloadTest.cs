using BaleLib;
using Xunit;

namespace BaleLibTest
{
    public class DownloadTest : BaseTest
    {
        [Fact]
        public void Download_file()
        {
            BaleClient client = new BaleClient(Token);
            client.DownloadFile(ChatId, FileId, "S:\\baleDownload", "photo.jpg");
        }
    }
}
    