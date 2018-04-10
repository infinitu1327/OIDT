using Models.Parameters;

namespace Models.Events
{
    public class StageStartEvent : Event
    {
        public virtual StageStartParameters Parameters { get; set; }
    }
}