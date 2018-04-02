namespace Models
{
    public class FirstLaunchParameters
    {
        public FirstLaunchParameters(JsonParameters parameters)
        {
            Id = parameters.Id;
            Gender = parameters.Gender;
            Age = parameters.Age.Value;
            Country = parameters.Country;
        }

        public int Id { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }

        public override string ToString()
        {
            return $"{Id},{Age},{Country},{Gender}";
        }
    }
}