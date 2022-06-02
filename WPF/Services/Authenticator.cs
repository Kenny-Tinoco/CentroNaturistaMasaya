using Domain.Entities;
using Domain.Services;
using Domain.Utilities;
using System;
using System.Threading.Tasks;
using WPF.Stores;

namespace WPF.Services
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAccountStore _accountStore;
        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAccountStore accountStore, IAuthenticationService authenticationService)
        {
            _accountStore = accountStore;
            _authenticationService = authenticationService;
        }

        public Account currentAccount
        {
            get => _accountStore.currentAccount;
            set
            {
                _accountStore.currentAccount = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;

        public bool isLoggedIn => currentAccount is not null;

        public async Task Login(string userName, string password) => 
            currentAccount = await _authenticationService.Login(userName, password);

        public void Logout() => currentAccount = null;

        public async Task<RegistrationResult> Register(int idEmployee, string userName, string password, string confirmPassword) =>
            await _authenticationService.Register(idEmployee, userName, password, confirmPassword);
    }
}
