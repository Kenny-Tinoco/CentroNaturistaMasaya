using Domain.Entities;
using Domain.Utilities;

namespace Domain.Services
{
    public interface IAuthenticationService
    {
        Task<Account> Login(string userName, string password);

        Task<RegistrationResult> Register(int idEmployee, string userName, string password, string confirmPassword);
    }
}
