using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Global.DataAccess.Data.Table;
using Global.Domain.Model;

namespace Global.Domain.Helper
{
  public class ApplicationMapper :Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Membership, MembershipModel>().ReverseMap();
            CreateMap<PurchaseOrder, PurchaseOrderModel>().ReverseMap();
            CreateMap<Subscription, SubscriptionModel>().ReverseMap();
            CreateMap<Addresses, AddressModel>().ReverseMap();
            CreateMap<Club, ClubModel>().ReverseMap();
        }
    }
}
