using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeryStore.Entities
{
    [Table("Order")]
    public class Order
    {
        [Key] [Column("orderid")]
        public int OrderID { get; set; }

        [Column("orderstatus")]
        public string OrderStatus { get; set; }

        [Column("orderdeliverydate")]
        public DateTime OrderDeliveryDate { get; set; }

        [Column("orderpickupoint")]
        public string OrderPickupPoint { get; set; }
    }

}
