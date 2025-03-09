﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tables
{
    public class Role
    {
        [Key, Required]
        public int Id { get; set; }

        public string Value { get; set; } = null!;

        public ICollection<User> Users { get; set; }
    }
}
