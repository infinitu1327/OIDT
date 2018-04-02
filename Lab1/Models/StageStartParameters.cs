namespace Models
{
    public class StageStartParameters
    {
        public StageStartParameters(JsonParameters parameters)
        {
            Id = parameters.Id;
            Stage = parameters.Stage.Value;
        }

        public int Id { get; set; }
        public int Stage { get; set; }

        public override string ToString()
        {
            return $"{Id},{Stage}";
        }
    }
}