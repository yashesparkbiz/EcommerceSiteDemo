

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceSiteDemo.Data.Data
{
    public class Product_subcategory
    {
        [Key]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; } = string.Empty;

        [Column("category_id", TypeName = "int")]
        [Display(Name = "Product_category")]
        public virtual int Category_Id { get; set; }

        [ForeignKey("Category_Id")]
        public virtual Product_category Product_category { get; set; } = new Product_category();

        [Column("created_at", TypeName = "datetime")]
        public DateTime Created_At { get; set; }

        [Column("updated_at", TypeName = "datetime")]
        public DateTime Updated_At { get; set; }
    }
}
