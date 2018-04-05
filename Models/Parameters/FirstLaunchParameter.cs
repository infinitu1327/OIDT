using Models.Events;

namespace Models.Parameters
{
    public class FirstLaunchParameter
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }

        public virtual FirstLaunchEvent Event { get; set; }
    }
}