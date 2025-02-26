using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeryStore.Entities
{
    public class OrderViewEntity
    {
        public int OrderID { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalDiscount { get; set; }
        public int ProductCount { get; set; }
        public int AvailableProductCount { get; set; }
        public bool FullyAvailable { get; set; }
    }

}
