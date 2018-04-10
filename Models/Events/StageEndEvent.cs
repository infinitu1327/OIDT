using Models.Parameters;

namespace Models.Events
{
    public class StageEndEvent : Event
    {
        public virtual StageEndParameters Parameters { get; set; }
    }
}