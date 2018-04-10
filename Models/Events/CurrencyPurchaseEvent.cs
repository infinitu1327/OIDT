using Models.Parameters;

namespace Models.Events
{
    public class CurrencyPurchaseEvent : Event
    {
        public virtual CurrencyPurchaseParameters Parameters { get; set; }
    }
}