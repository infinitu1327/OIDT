namespace ImportRecords.Models.Parameters
{
    public class StageStartParameter : Parameter
    {
        public StageStartParameter()
        {
        }

        public StageStartParameter(JsonParameters parameters)
        {
            Id = parameters.Id;
            Stage = parameters.Stage.Value;
        }

        public int Stage { get; set; }

        public override string ToString()
        {
            return $"{Id},{Stage}";
        }
    }
}