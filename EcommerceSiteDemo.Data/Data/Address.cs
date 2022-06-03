using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSiteDemo.Data.Data
{
    public class Address
    {
        [Key]
        [Column("id",TypeName = "int")]
        public int Id { get; set; }

        [Column("house", TypeName = "varchar(100)")]
        public string House { get; set; } = string.Empty;   

        [Column("street", TypeName = "varchar(100)")]
        public string Street { get; set; } = string.Empty ;

        [Column("city", TypeName = "varchar(100)")]
        public string City { get; set; } = string.Empty;

        [Column("country", TypeName = "varchar(100)")]
        public string Country { get; set; } = string.Empty;

        [Column("pincode", TypeName = "varchar(20)")]
        public string Pincode { get; set; } = string.Empty;

        [Column("address_type", TypeName = "varchar(20)")]
        public string Address_Type { get; set; } = string.Empty;
    }
}
