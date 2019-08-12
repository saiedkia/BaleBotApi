namespace BaleLib.Models
{
    public class Payment
    {
        public string Currency { get; set; }
        public long TotalAmount { get; set; }
        public string InvoicePayload { get; set; }
        public string ShippingOptionId { get; set; }
        public string TelegramPaymentChargeId { get; set; }
        public string ProviderPaymentChargeId { get; set; }
        public OrderInfo OrderInfo { get; set; }
    }
}
