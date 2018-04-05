using Models.Parameters;

namespace ImportRecords.Models.Parameters
{
    public class CurrencyPurchaseParameter : Parameter
    {
        public CurrencyPurchaseParameter()
        {
        }

        public CurrencyPurchaseParameter(JsonParameters parameters)
        {
            Id = parameters.Id;
            Name = parameters.Name;
            Price = parameters.Price.Value;
            Income = parameters.Income.Value;
        }

        public int Income { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Id},{Income},{Name},{Price}";
        }
    }
}