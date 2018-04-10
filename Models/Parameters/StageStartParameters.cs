using Models.Events;

namespace Models.Parameters
{
    public class StageStartParameters
    {
        public StageStartParameters()
        {
        }

        public StageStartParameters(JsonParameters parameters)
        {
            Id = parameters.Id;
            Stage = parameters.Stage.Value;
        }

        public int Id { get; set; }
        public int Stage { get; set; }

        public virtual StageStartEvent Event { get; set; }
    }
}