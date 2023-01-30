using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Domain.Model
{
    public class SubscriptionModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public int ClubId { get; set; }

        public int PoId { get; set; }


        //true->PO mebershipId based; false->PO mebershipId based
        public bool IsPremiumUser { get; set; }

        //ShipingSlip generated fk of IsPhysicalProduct
        public bool IsShippingSlipGenerated { get; set; }

        public AddressModel AddressDetails { get; set; }
    }

    
}
