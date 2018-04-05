using System;
using Models;
using Newtonsoft.Json;

namespace ImportRecords.Models
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
            return EventId == 1 ? $"{Id},{Date},{Udid}" : $"{Id},{Date},{Parameters.Id},{Udid}";
        }
    }
}