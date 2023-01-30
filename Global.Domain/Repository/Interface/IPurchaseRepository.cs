using System.Threading.Tasks;
using Global.Domain.Model;

namespace Global.Domain.Repository.Interface
{
    public interface IPurchaseRepository
    {
        Task<SubscriptionModel> PurchaseMembership(PurchaseOrderModel model);
        bool GetMembershipType(int id);
        Task<AddressModel> CreateAddress2User(AddressModel model);
        Task<SubscriptionModel> CreateSubscription2User(SubscriptionModel model);
    }
}