using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeryStore.Entities
{
    [Table("product")]
    public class Product
    {
        [Key] [Column("productarticlenumber")]
        public string ProductArticleNumber { get; set; }

        [Column("productname")]
        public string ProductName { get; set; }

        [Column("productdescription")]
        public string ProductDescription { get; set; }

        [Column("productcategory")]
        public string ProductCategory { get; set; }

        [Column("productphoto")]
        public string ProductPhoto { get; set; }

        [Column("productmanufacturer")]
        public string ProductManufacturer { get; set; }

        [Column("productcost")]
        public decimal ProductCost { get; set; }

        [Column("productdiscountamount")]
        public int? ProductDiscountAmount { get; set; }

        [Column("productquantityinstock")]
        public int ProductQuantityInStock { get; set; }

        [Column("productstatus")]
        public string ProductStatus { get; set; }

      
        }

    }

