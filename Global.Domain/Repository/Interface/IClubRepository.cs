using System.Threading.Tasks;
using Global.Domain.Model;

namespace Global.Domain.Repository.Interface
{
    public interface IClubRepository
    {
        Task<int> CreateClub(ClubModel model);
    }
}