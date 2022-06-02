using Domain.Entities;
using System;

namespace WPF.Stores
{
    public interface IAccountStore
    {
        Account currentAccount { get; set; }

        event Action StateChanged;
    }
}