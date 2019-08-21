namespace BaleLib.Models
{
    public class Price
    {
        public string Label { get; set; }
        public long Amount { get; set; }

        public Price()
        {
        }

        public Price(string label, long amount)
        {
            Label = label;
            Amount = amount;
        }
    }
}
