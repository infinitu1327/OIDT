using System.Runtime.Serialization;

namespace Models.Parameters
{
    public class JsonParameters
    {
        public int Id { get; set; }

        [DataMember(Name = "gender")] public string Gender { get; set; }

        [DataMember(Name = "age")] public int? Age { get; set; }

        [DataMember(Name = "country")] public string Country { get; set; }

        [DataMember(Name = "stage")] public int? Stage { get; set; }

        [DataMember(Name = "win")] public bool? Win { get; set; }

        [DataMember(Name = "time")] public int? Time { get; set; }

        [DataMember(Name = "income")] public int? Income { get; set; }

        [DataMember(Name = "item")] public string Item { get; set; }

        [DataMember(Name = "price")] public decimal? Price { get; set; }

        [DataMember(Name = "name")] public string Name { get; set; }
    }
}