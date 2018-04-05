using Models.Parameters;

namespace ImportRecords.Models.Parameters
{
    public class InGamePurchaseParameter : Parameter
    {
        public InGamePurchaseParameter()
        {
        }

        public InGamePurchaseParameter(JsonParameters parameters)
        {
            Id = parameters.Id;
            Item = parameters.Item;
            Price = (int) parameters.Price.Value;
        }

        public string Item { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"{Id},{Item},{Price}";
        }
    }
}