using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asmpro131_Shared.Models
{
    public class Cart
    {
        [Key]
        public Guid AccountID { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<CartDetails>? CartDetails { get; set; }
        public virtual Account? Account { get; set; }
    }
}
