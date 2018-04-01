using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class DAU
    {
        [Key]
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}