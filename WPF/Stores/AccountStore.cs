using Domain.Entities;
using System;

namespace WPF.Stores
{
    public class AccountStore : IAccountStore
    {
        private Account _currentAccount;

        public Account currentAccount
        {
            get { return _currentAccount; }
            set
            {
                _currentAccount = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;
    }
}
