using Models.Events;

namespace Models.Parameters
{
    public class CurrencyPurchaseParameter
    {
        public int Id { get; set; }
        public int Income { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual CurrencyPurchaseEvent Event { get; set; }
    }
}