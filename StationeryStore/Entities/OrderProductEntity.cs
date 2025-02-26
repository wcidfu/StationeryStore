using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeryStore.Entities
{
    [Table("orderproduct")]
    public class OrderProduct
    {
        [Key] [Column("orderid")]
        public int OrderID { get; set; }

        [Column("productarticlenumber")]
        public string ProductArticleNumber { get; set; }
        public int Quantity { get; set; }
    }

}
