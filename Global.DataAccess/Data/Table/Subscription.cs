using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.DataAccess.Data.Table
{
    public class Subscription
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public int ClubId { get; set; }

        [ForeignKey("ClubId")]
        public Club Club { get; set; }

        public int PoId { get; set; }
       
        [ForeignKey("PoId")]
        public PurchaseOrder PurchaseOrder { get; set; }
        public bool IsPremiumUser { get; set; }
        public bool IsShippingSlipGenerated { get; set; }
 
    }
}
