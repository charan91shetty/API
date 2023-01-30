using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Domain.Model;

namespace Global.Domain.Repository.Interface
{
   public interface IMembershipRepository
    {
        Task<List<MembershipModel>> GetAllMembershipAsync();
        Task<MembershipModel> GetMembershipByIdsAsync(int membershipId);
        Task<int> AddMemberAsync(MembershipModel model);
    }
}
