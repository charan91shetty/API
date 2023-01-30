using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.DataAccess.Data.Table
{
    public class PurchaseOrder
    {
        public int Id { get; set; }

        public int PoNumber { get; set; }
        public double Total { get; set; }

        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public ApplicationUser ApplicationUser { get; set; }

        public int MembershipId { get; set; }

        [ForeignKey("MembershipId")]
        public Membership Membership { get; set; }

        public int ClubId { get; set; }

        [ForeignKey("ClubId")]
        public Club Club { get; set; }

        public bool IsPhysicalProduct { get; set; }

        public int DeliveryAddress { get; set; }

        [ForeignKey("DeliveryAddress")]
        public Addresses Addresses { get; set; }

    }
}
