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
    Text = "hi, please [visit my website](httP://saiedkia.ir)"
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

- Send invoice
```C#
BaleClient client = new BaleClient(Token);
Response response = client.SendInvoice(
	new InvoiceMessage(ChatId,
		"paloadData", 
		"pizza chicago", 
		"pizza chicago with special souce", 
		"uniqueFactorId", new Price("pizza chicago", 300_000)
	)).Result;
```
### Console application sample:
https://gitlab.com/saiedkia/bale-echo
