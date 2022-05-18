using MVVMGenericStructure.ViewModels;

namespace WPF.ViewModel.Base
{
    public class MessageViewModel : ViewModelBase
    {
        private string _message;

        public string message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(message));
                OnPropertyChanged(nameof(hasMessage));
            }
        }

        public bool hasMessage => !string.IsNullOrEmpty(message);
    }
}
