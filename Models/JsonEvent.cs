using System;
using Newtonsoft.Json;

namespace Models
{
    public class JsonEvent
    {
        public int Id { get; set; }
        public string Udid { get; set; }
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "event_id")]
        public short EventId { get; set; }

        public JsonParameters Parameters { get; set; }

        public override string ToString()
        {
            return $"{Id},{Date},{EventId},{Parameters.Id},{Udid}";
        }
    }
}