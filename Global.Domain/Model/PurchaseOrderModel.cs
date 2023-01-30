using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Domain.Model
{
    public class PurchaseOrderModel
    {
        public int Id { get; set; }
        public int PoNumber { get; set; }
        public double Total { get; set; }
        public string CustomerId { get; set; }
        public int MembershipId { get; set; }
        public int ClubId { get; set; }
        public bool IsPhysicalProduct { get; set; }
        public int DeliveryAddress { get; set; }
        public AddressModel NewAddressDetails { get; set; }
    }
}
