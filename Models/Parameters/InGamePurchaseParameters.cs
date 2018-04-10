using Models.Events;

namespace Models.Parameters
{
    public class InGamePurchaseParameters
    {
        public InGamePurchaseParameters()
        {
        }

        public InGamePurchaseParameters(JsonParameters parameters)
        {
            Id = parameters.Id;
            Item = parameters.Item;
            Price = (int) parameters.Price.Value;
        }

        public int Id { get; set; }
        public string Item { get; set; }
        public int Price { get; set; }

        public virtual InGamePurchaseEvent Event { get; set; }
    }
}