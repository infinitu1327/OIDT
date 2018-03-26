using System;
using Newtonsoft.Json;

namespace Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Udid { get; set; }
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "event_id")]
        public short EventId { get; set; }

        public int? ParametersId { get; set; }
        public Parameters Parameters { get; set; }

        public override string ToString()
        {
            return $"{Id},{Date},{EventId},{ParametersId},{Udid}";
        }

        public override bool Equals(object obj)
        {
            return ((Event) obj).Udid == Udid;
        }
    }
}