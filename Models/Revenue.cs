using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Revenue
    {
        [Key]
        public DateTime Date { get; set; }
        public decimal Income { get; set; }
    }
}