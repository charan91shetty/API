using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Global.DataAccess.Data;
using Global.DataAccess.Data.Table;
using Global.Domain.Model;
using Global.Domain.Model.enums;
using Global.Domain.Repository.Interface;

namespace Global.Domain.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private FunBooksAndVideosStoreDbContext _funBooksAndVideosStoreDbContext;
        private IMapper _mapper;

        public PurchaseRepository(FunBooksAndVideosStoreDbContext funBooksAndVideosStoreDbContext, IMapper mapper)
        {
            _funBooksAndVideosStoreDbContext = funBooksAndVideosStoreDbContext;
            _mapper = mapper;
        }
        public async Task<SubscriptionModel> PurchaseMembership(PurchaseOrderModel model)
        {
            try
            {
                var purchaseOrder = _mapper.Map<PurchaseOrder>(model);
                var poData = _funBooksAndVideosStoreDbContext.PurchaseOrder.Add(purchaseOrder);
                _funBooksAndVideosStoreDbContext.SaveChanges();
                var purchaseMembershipObject = _mapper.Map<PurchaseOrderModel>(poData.Entity);
                //todo -purchase order mebership id ->get membership type
                SubscriptionModel subscriptionModel = new SubscriptionModel()
                {

                    UserId = purchaseMembershipObject.CustomerId,
                    ClubId = purchaseMembershipObject.ClubId,
                    PoId = purchaseMembershipObject.Id,
                    IsPremiumUser = GetMembershipType(purchaseMembershipObject.MembershipId),
                    IsShippingSlipGenerated = purchaseMembershipObject.IsPhysicalProduct,

                    AddressDetails = purchaseMembershipObject.IsPhysicalProduct ? new AddressModel()
                    {
                        AddressType = purchaseMembershipObject.NewAddressDetails.AddressType,// AddressType.shipping,
                        AddressLineOne = purchaseMembershipObject.NewAddressDetails.AddressLineOne,
                        AddressLine2 = purchaseMembershipObject.NewAddressDetails.AddressLine2,
                        PostalCode = purchaseMembershipObject.NewAddressDetails.PostalCode,
                    } : null,


                };
                var subscriptionDetail = await CreateSubscription2User(subscriptionModel);
                return subscriptionDetail;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public bool GetMembershipType(int id)
        {
            //todo-fetch mebership object based on id
            //todo apply condition and send true or false details.
            //if membership product id is 4 then user is purchased audio and video both product

            return (id == 4);

        }

        public async Task<AddressModel> CreateAddress2User(AddressModel model)
        {
            try
            {
                var addressModel = _mapper.Map<Addresses>(model);
                var subscriptionData = _funBooksAndVideosStoreDbContext.Addresses.Add(addressModel);
                _funBooksAndVideosStoreDbContext.SaveChanges();
                var addressModelObject = _mapper.Map<AddressModel>(subscriptionData.Entity);
                return addressModelObject;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<SubscriptionModel> CreateSubscription2User(SubscriptionModel model)
        {
            var subscriptionModel = _mapper.Map<Subscription>(model);
            var subscriptionData = _funBooksAndVideosStoreDbContext.Subscription.Add(subscriptionModel);
            _funBooksAndVideosStoreDbContext.SaveChanges();
            var subscriptionModelObject = _mapper.Map<SubscriptionModel>(subscriptionData.Entity);
            return subscriptionModelObject;
        }
    }
}

