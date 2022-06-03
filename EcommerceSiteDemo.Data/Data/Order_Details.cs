using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSiteDemo.Data.Data
{
    public class Order_Details
    {
        [Key]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("product_id", TypeName = "int")]
        [Display(Name = "Product")]
        public virtual int Product_Id { get; set; }

        [ForeignKey("Product_Id")]
        public virtual Product Product { get; set; } = new Product() { };

        [Column("quantity", TypeName = "int")]
        public int Quantity { get; set; }

        [Column("delivery_address_id", TypeName = "int")]
        public int Delivery_Address_Id { get; set; }

        [Column("order_id", TypeName = "int")]
        [Display(Name = "Order")]
        public virtual int Order_Id { get; set; }

        [ForeignKey("Order_Id")]
        public virtual Order Order { get; set; } = new Order() { };

        [Column("status", TypeName = "varchar(50)")]
        public string Status { get; set; } = string.Empty;

        [Column("discount_id", TypeName = "int")]
        [Display(Name = "Discount")]
        public virtual int Discount_Id { get; set; }

        [ForeignKey("Discount_Id")]
        public virtual Discount Discount { get; set; } = new Discount() { };

        [Column("created_at", TypeName = "datetime")]
        public DateTime Created_At { get; set; } = DateTime.Now;

        [Column("updated_at", TypeName = "datetime")]
        public DateTime Updated_At { get; set; } = DateTime.Now;
    }
}
