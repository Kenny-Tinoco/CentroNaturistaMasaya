using Domain.DAO;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Utilities;

namespace Domain.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AccountDAO accountService;

        public AuthenticationService(AccountDAO _accountService)
        {
            accountService = _accountService;
        }

        public async Task<Account> Login(string userName, string password)
        {
            Account storedAccount = await accountService.GetByUserName(userName);

            if (storedAccount is null)
            {
                throw new UserNotFoundException(userName);
            }

            bool success = await accountService.VerifyPassword(userName, password);
            if (!success)
            {
                throw new InvalidPasswordException(userName, password);
            }

            return storedAccount;
        }

        public async Task<RegistrationResult> Register(int idEmployee, string userName, string password, string confirmPassword)
        {
            if (password != confirmPassword)
                return RegistrationResult.PasswordDoNotMatch;

            Account userNameAccount = await accountService.GetByUserName(userName);
            if (userNameAccount is not null)
                return RegistrationResult.UsernameAlreadyExists;

            Account account = new()
            {
                IdEmployee = idEmployee,
                UserName = userName,
                Password = password,
                Created = DateTime.Now
            };

            await accountService.Create(account);

            return RegistrationResult.Success;
        }
    }
}
