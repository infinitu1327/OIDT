using Models.Parameters;

namespace ImportRecords.Models.Parameters
{
    public class FirstLaunchParameter : Parameter
    {
        public FirstLaunchParameter()
        {
        }

        public FirstLaunchParameter(JsonParameters parameters)
        {
            Id = parameters.Id;
            Gender = parameters.Gender;
            Age = parameters.Age.Value;
            Country = parameters.Country;
        }

        public int Age { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }

        public override string ToString()
        {
            return $"{Id},{Age},{Country},{Gender}";
        }
    }
}