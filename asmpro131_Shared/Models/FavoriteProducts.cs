﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asmpro131_Shared.Models
{
    public class FavoriteProducts
    {
        [Key]
        [Column(Order = 0)]
        public Guid AccountID { get; set; }
        [Key]
        [Column(Order = 1)]
        public Guid ProductID { get; set; }

        public string Description { get; set; }
        [ForeignKey("ProductID")]
        public Product? Products { get; set; }
        [ForeignKey("AccountID")]
        public virtual Account? Account { get; set; }
    }
}
