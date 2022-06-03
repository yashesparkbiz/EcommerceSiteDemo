using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSiteDemo.Data.Data
{
    public class Order
    {
        [Key]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("total_amount", TypeName = "decimal(6,2)")]
        public decimal Total_Amount { get; set; }

        [Column("total_discount", TypeName = "decimal(6,2)")]
        public decimal Total_Discount { get; set; }

        [Column("user_id", TypeName = "int")]
        [Display(Name = "User")]
        public virtual int User_Id { get; set; }

        [ForeignKey("User_Id")]
        public virtual User User { get; set; } = new User();

        [Column("created_at", TypeName = "datetime")]
        public DateTime Created_At { get; set; } = DateTime.Now;

        [Column("updated_at", TypeName = "datetime")]
        public DateTime Updated_At { get; set; } = DateTime.Now;
    }
}