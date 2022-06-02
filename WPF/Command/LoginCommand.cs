using Domain.Exceptions;
using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using WPF.Services;
using WPF.ViewModel;

namespace WPF.Command
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly INavigationService _pageNavigation;
        private readonly INavigationService _closeModal;

        public LoginCommand(LoginViewModel loginViewModel, IAuthenticator authenticator, INavigationService pageNavigation, INavigationService closeModal)
        {
            _authenticator = authenticator;
            _loginViewModel = loginViewModel;
            _pageNavigation = pageNavigation;
            _closeModal = closeModal;

            _loginViewModel.PropertyChanged += LoginViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter) =>
            _loginViewModel.canLogin && base.CanExecute(parameter);

        public override async Task ExecuteAsync(object parameter)
        {
            _loginViewModel.errorMessage = string.Empty;
            try
            {
                await _authenticator.Login(_loginViewModel.userName, _loginViewModel.password);
                Navigate();
            }
            catch (UserNotFoundException)
            {
                _loginViewModel.errorMessage = "Usuario no existe.";
            }
            catch (InvalidPasswordException)
            {
                _loginViewModel.errorMessage = "Contraseña incorrecta.";
            }
            catch (Exception)
            {
                _loginViewModel.errorMessage = "Falló el inicio de sesión.";
            }
        }

        private void Navigate()
        {
            _closeModal.Navigate();
            _pageNavigation.Navigate();
        }

        private void LoginViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.canLogin))
                OnCanExecuteChanged();
        }

    }
}
