using System;
using System.Runtime.Serialization;
using Models.Parameters;

namespace Models.Events
{
    public class JsonEvent
    {
        public int Id { get; set; }
        [DataMember(Name = "udid")] private string Udid { get; set; }
        [DataMember(Name = "date")] private DateTime Date { get; set; }
        public short EventId { get; set; }

        [DataMember(Name = "parameters")] public JsonParameters Parameters { get; set; }

        public override string ToString()
        {
            return EventId == 1 ? $"{Id},{Date},{Udid}" : $"{Id},{Date},{Parameters.Id},{Udid}";
        }
    }
}