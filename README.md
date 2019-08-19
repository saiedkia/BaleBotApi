# BaleBotApi
Bale Messenger Bot Api in C# 

## Installation
from nuget package:
```
Install-Package BaleBotApi
```

## Usage

- Send message
```C#
BaleClient client = new BaleClient(Token);
client.SendTextMessage(new TextMessage()
{
    ChatId = ChatId,
    Text = "salam"
});
```

- Send audio message
```C#
BaleClient client = new BaleClient(Token);
Response response = client.SendAudio(new AudioMessage()
{
    Caption = "audio caption",
    ChatId = ChatId,
    Audio = Utils.ToBytes(FilePath + "gun_sound.mp3"),
    Title = "audio title"
});
```
