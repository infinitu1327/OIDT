using Models.Events;

namespace Models.Parameters
{
    public class StageEndParameter
    {
        public int Id { get; set; }
        public int? Income { get; set; }
        public int Stage { get; set; }
        public int Time { get; set; }
        public bool Win { get; set; }

        public virtual StageEndEvent Event { get; set; }
    }
}