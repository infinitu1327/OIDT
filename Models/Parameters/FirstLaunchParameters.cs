using Models.Events;

namespace Models.Parameters
{
    public class FirstLaunchParameters
    {
        public FirstLaunchParameters()
        {
        }

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

        public virtual FirstLaunchEvent Event { get; set; }
    }
}