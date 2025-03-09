using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tables
{
    public class ToyImage
    {
        [Key,Required]
        public int Id { get; set; }
        public string Path { get; set; } = null!;
        public ICollection<Toy> Toys { get; set; }
    }
}
