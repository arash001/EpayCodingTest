﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Denomination
    {
        [Key]
        public int Id { get; set; }
        public int Value { get; set; }
    }
}
