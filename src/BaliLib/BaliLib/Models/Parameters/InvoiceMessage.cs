using System.Collections.Generic;

namespace BaleLib.Models.Parameters
{
    public class InvoiceMessage : BaseInput
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProviderToken { get; set; }
        public List<Price> Prices { get; set; }
        public string Payload { get; set; }

        public string ProviderData { get; set; }
        public string PhotoUrl { get; set; }
        public string StartParameter { get; set; }

        public bool? NeedName { get; set; }
        public bool? NeedPhoneNumber { get; set; }
        public bool? NeedEmail { get; set; }
        public bool? NeedShippingAddress { get; set; }
        public bool? IsFlexible { get; set; }
        public bool? DisableNotification { get; set; }


        public InvoiceMessage(long chatId, string payLoad, string title, string description, string providerToken, List<Price> prices)
        {
            ChatId = chatId;
            Payload = payLoad;
            Title = title;
            Description = description;
            ProviderToken = providerToken;
            Prices = prices;
        }


        public InvoiceMessage(long chatId, string payLoad, string title, string description, string providerToken, Price price)
        {
            ChatId = chatId;
            Payload = payLoad;
            Title = title;
            Description = description;
            ProviderToken = providerToken;
            Prices = new List<Price>() { price };
        }

    }
}
