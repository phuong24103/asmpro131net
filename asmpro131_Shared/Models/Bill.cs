using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asmpro131_Shared.Models
{
    public class Bill
    {
        [Key]
        public Guid Id { get; set; }
        public double Price { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        [ForeignKey("VoucherID")]
        public Guid? VoucherID { get; set; }
        public string Adress { get; set; }
        [ForeignKey("AccountID")]
        public Guid AccountID { get; set; }
        public virtual ICollection<BillDetails>? BillDetails { get; set; }
        public virtual Voucher? Voucher { get; set; }
        public virtual Account? Account { get; set; }
        public virtual BillStatus? BillStatus { get; set; }
        public virtual Payment? Payment { get; set; }
    }
}
