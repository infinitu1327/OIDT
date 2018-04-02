namespace Models
{
    public class GameLaunchParameters
    {
        public GameLaunchParameters(JsonParameters parameters)
        {
            Id = parameters.Id;
        }

        public int Id { get; set; }

        public override string ToString()
        {
            return $"{Id}";
        }
    }
}