using Models.Events;

namespace Models.Parameters
{
    public class StageStartParameter
    {
        public int Id { get; set; }
        public int Stage { get; set; }

        public virtual StageStartEvent Event { get; set; }
    }
}