using Domain.Entities;
using Domain.Utilities;
using System.Threading.Tasks;

namespace WPF.Services
{
    public interface IAuthenticator
    {
        Account currentAccount { get; }

        bool isLoggedIn { get; }

        Task<RegistrationResult> Register(int idEmployee, string userName, string password, string confirmPassword);

        Task Login(string userName, string password);

        void Logout();
    }
}
