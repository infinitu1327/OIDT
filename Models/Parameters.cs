namespace Models
{
    public class Parameters
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Country { get; set; }
        public int? Stage { get; set; }
        public bool? Win { get; set; }
        public int? Time { get; set; }
        public int? Income { get; set; }
        public string Item { get; set; }
        public decimal? Price { get; set; }

        public bool NotNull()
        {
            return !string.IsNullOrEmpty(Gender) ||
                   Age.HasValue ||
                   !string.IsNullOrEmpty(Country) ||
                   Stage.HasValue ||
                   Win.HasValue ||
                   Time.HasValue ||
                   Income.HasValue ||
                   !string.IsNullOrEmpty(Item) ||
                   Price.HasValue;
        }

        public override string ToString()
        {
            return $"{Id},{Age},{Country},{Gender},{Income},{Item},{Price},{Stage},{Time},{Win}";
        }
    }
}