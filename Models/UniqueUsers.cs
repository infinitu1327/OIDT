using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class UniqueUsers
    {
        [Key]
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}