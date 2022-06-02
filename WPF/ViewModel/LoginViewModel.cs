using MVVMGenericStructure.Services;
using System.Windows.Input;
using WPF.Command;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public class LoginViewModel : ModalViewModel
    {
        private MessageViewModel _errorViewModel { get; }

        public LoginViewModel(IAuthenticator authenticator, INavigationService homePage, INavigationService closeModal) : base(closeModal)
        {
            loginCommand = new LoginCommand(this, authenticator, homePage, closeModal);

            _errorViewModel = new MessageViewModel();

            exitCommand = new StateBarCommand();
        }


        public string titleBar => "Inicio de Sesión";

        private string _userName;
        public string userName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(userName));
                OnPropertyChanged(nameof(canLogin));
            }
        }

        private string _password;
        public string password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(password));
                OnPropertyChanged(nameof(canLogin));
            }
        }

        public bool canLogin => !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password);

        public string errorMessage
        {
            get => _errorViewModel.message;
            set
            {
                _errorViewModel.message = value;
                OnPropertyChanged(nameof(errorMessage));
                OnPropertyChanged(nameof(hasErrorMessage));
            }
        }

        public bool hasErrorMessage => _errorViewModel.hasMessage;

        public ICommand loginCommand { get; }

        public ICommand exitLoginCommand => new RelayCommand(o =>
        {
            exitCommand.Execute("exit");
        });

        public override void Dispose()
        {
            _errorViewModel.Dispose();

            base.Dispose();
        }
    }
}
