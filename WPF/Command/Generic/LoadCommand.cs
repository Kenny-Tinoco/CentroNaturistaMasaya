using MVVMGenericStructure.Commands;
using MVVMGenericStructure.ViewModels;
using System.Threading.Tasks;
using WPF.ViewModel.Base;

namespace WPF.Command.Generic
{
    public class LoadCommand : AsyncCommandBase
    {
        private readonly ListingViewModel viewModel;

        public LoadCommand(ViewModelBase parameter)
        {
            viewModel = (ListingViewModel)parameter;
        }

        public override async Task ExecuteAsync(object parameter = null)
        {
            viewModel.isLoading = true;
            viewModel.errorMessage = string.Empty;
            try
            {
                await viewModel.Load();
            }
            catch
            {
                viewModel.errorMessage = "Error a cargar los datos";
            }
            viewModel.isLoading = false;
        }
    }
}
