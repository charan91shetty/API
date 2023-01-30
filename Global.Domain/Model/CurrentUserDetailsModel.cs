using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.DataAccess.Data.Table;

namespace Global.Domain.Model
{
    public class CurrentUserDetailsModel
    {
        public string UserName { get; set; }

        public Subscription SubscriptionDetails { get; set; }
    }
}
