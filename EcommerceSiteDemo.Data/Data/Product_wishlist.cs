
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceSiteDemo.Data.Data
{
    public class Product_wishlist
    {
        [Key]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("product_id", TypeName = "int")]
        [Display(Name = "Product")]
        public virtual int Product_Id { get; set; }

        [ForeignKey("Product_Id")]
        public virtual Product Product { get; set; } = new Product();

        [Column("user_id", TypeName = "int")]
        [Display(Name = "User")]
        public virtual int User_Id { get; set; }

        [ForeignKey("User_Id")]
        public virtual User User { get; set; } = new User();

        [Column("created_at", TypeName = "datetime")]
        public DateTime Created_At { get; set; }
        
        [Column("updated_at", TypeName = "datetime")]
        public DateTime Updated_At { get; set; }
    }
}
