using Models.Parameters;

namespace Models.Events
{
    public class StageEndEvent : Event
    {
        public virtual StageEndParameter Parameters { get; set; }
    }
}