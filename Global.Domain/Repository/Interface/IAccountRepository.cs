using System.Threading.Tasks;
using Global.Domain.Model;
using Microsoft.AspNetCore.Identity;

namespace Global.Domain.Repository.Interface
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignupAsnc(SignUpModel signUpModel);
        Task<string> LogInAsync(SignInModel signInModel);
        Task<bool> LogOutAsync(SignUpModel signOutModel);
    }
}