using Models.Parameters;

namespace Models.Events
{
    public class InGamePurchaseEvent : Event
    {
        public virtual InGamePurchaseParameters Parameters { get; set; }
    }
}