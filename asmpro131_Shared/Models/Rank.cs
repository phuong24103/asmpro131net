﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asmpro131_Shared.Models
{
    public class Rank
    {

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Point { get; set; }
        public virtual ICollection<Account>? Accounts { get; set; }
    }
}
