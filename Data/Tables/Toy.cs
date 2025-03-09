using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tables
{
    public class Toy
    {
        [Key,Required]
        public int Id { get; set; }

        [Required, Range(0, double.MaxValue)]
        public double Price { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        public ICollection<ToyImage> ToyImage { get; set; }

        [Required, Range(0, double.MaxValue)]
        public int Count { get; set; }
    }
}
