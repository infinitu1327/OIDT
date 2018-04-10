using System;

namespace Models.Events
{
    public class Event
    {
        public int Id { get; set; }
        public string Udid { get; set; }
        public DateTime Date { get; set; }

        public int ParametersId { get; set; }
    }
}