namespace Models
{
    public class CurrencyPurchaseParameters
    {
        public CurrencyPurchaseParameters(JsonParameters parameters)
        {
            Id = parameters.Id;
            Name = parameters.Name;
            Price = parameters.Price.Value;
            Income = parameters.Income.Value;
        }

        public int Id { get; set; }
        public int Income { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Id},{Income},{Name},{Price}";
        }
    }
}