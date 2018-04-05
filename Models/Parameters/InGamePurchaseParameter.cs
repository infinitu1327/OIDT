using Models.Events;

namespace Models.Parameters
{
    public class InGamePurchaseParameter
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public int Price { get; set; }

        public virtual InGamePurchaseEvent Event { get; set; }
    }
}