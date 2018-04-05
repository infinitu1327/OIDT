using Models.Parameters;

namespace Models.Events
{
    public class InGamePurchaseEvent : Event
    {
        public virtual InGamePurchaseParameter Parameters { get; set; }
    }
}