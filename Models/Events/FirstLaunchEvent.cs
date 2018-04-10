using Models.Parameters;

namespace Models.Events
{
    public class FirstLaunchEvent : Event
    {
        public virtual FirstLaunchParameters Parameters { get; set; }
    }
}