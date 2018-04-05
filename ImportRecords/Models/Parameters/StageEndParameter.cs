namespace ImportRecords.Models.Parameters
{
    public class StageEndParameter : Parameter
    {
        public StageEndParameter()
        {
        }

        public StageEndParameter(JsonParameters parameters)
        {
            Id = parameters.Id;
            Stage = parameters.Stage.Value;
            Win = parameters.Win.Value;
            Time = parameters.Time.Value;
            Income = parameters.Income;
        }

        public int? Income { get; set; }
        public int Stage { get; set; }
        public int Time { get; set; }
        public bool Win { get; set; }

        public override string ToString()
        {
            return $"{Id},{Income},{Stage},{Time},{(Win ? "1" : "0")}";
        }
    }
}