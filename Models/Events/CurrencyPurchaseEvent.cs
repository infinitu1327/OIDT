using Models.Parameters;

namespace Models.Events
{
    public class CurrencyPurchaseEvent : Event
    {
        public virtual CurrencyPurchaseParameter Parameters { get; set; }
    }
}