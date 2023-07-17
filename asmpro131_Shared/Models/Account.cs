using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asmpro131_Shared.Models
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        [MaxLength(10)]
        [RegularExpression(@"\d*[0-9]\d*", ErrorMessage = "The field PhoneNumber only has input number")]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public double Point { get; set; }
        public int Status { get; set; }
        [ForeignKey("RoleId")]
        public Guid RoleId { get; set; }
        [ForeignKey("RankID")]
        public Guid RankID { get; set; }
        public virtual ICollection<Bill>? Bills { get; set; }
        public virtual ICollection<FavoriteProducts>? FavoriteProducts { get; set; }
        public virtual Role? Role { get; set; }
        public virtual Rank? Rank { get; set; }
        public virtual Cart? Cart { get; set; }
    }
}
