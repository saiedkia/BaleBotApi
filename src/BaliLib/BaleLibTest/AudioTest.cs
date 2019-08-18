using BaleLib;
using BaleLib.Models;
using BaleLib.Models.Parameters;
using FluentAssertions;
using Xunit;

namespace BaleLibTest
{
    // gun sound mp3 file downloaded form:
    // https://www.soundjay.com/gun-sound-effect.html

    public class AudioTest : BaseTest
    {
        [Fact]
        public void Send_audio_successfully()
        {
            BaleClient client = new BaleClient(Token);
            Response response = client.SendAudio(new AudioMessage()
            {
                Caption = "audio caption",
                ChatId = ChatId,
                Audio = Utils.ToBytes(FilePath + "gun_sound.mp3"),
                Title = "audio titile"
            });

            response.Ok.Should().BeTrue();
            //response.Result.Audio.Should().NotBeNull();
        }
    }
}
