using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceSiteDemo.Data.Data
{
    public class Product_cart
    {
        [Key]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("product_id", TypeName = "int")]
        public int Product_Id { get; set; }

        [Column("quantity", TypeName = "int")]
        public int Quantity { get; set; }

        [Column("price", TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        [Column("user_id", TypeName = "int")]
        [Display(Name = "User")]
        public virtual int User_Id { get; set; }

        [ForeignKey("User_Id")]
        public virtual User User { get; set; } = new User();

        [Column("is_active", TypeName = "bit")]
        public bool Is_Active { get; set; }

        [Column("created_at", TypeName = "datetime")]
        public DateTime Created_At { get; set; } = DateTime.Now;

        [Column("updated_at", TypeName = "datetime")]
        public DateTime Updated_At { get; set; } = DateTime.Now;
    }
}