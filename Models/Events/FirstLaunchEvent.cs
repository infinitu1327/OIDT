using Models.Parameters;

namespace Models.Events
{
    public class FirstLaunchEvent : Event
    {
        public virtual FirstLaunchParameter Parameters { get; set; }
    }
}