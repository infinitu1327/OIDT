using Models.Parameters;

namespace Models.Events
{
    public class StageStartEvent : Event
    {
        public virtual StageStartParameter Parameters { get; set; }
    }
}