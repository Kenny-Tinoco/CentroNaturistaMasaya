using Domain.Entities;
using MVVMGenericStructure.Commands;
using MVVMGenericStructure.ViewModels;
using System.Threading.Tasks;
using WPF.ViewModel.Base;

namespace WPF.Command.CRUD
{
    public class LoadRecordListCommand<Entity> : AsyncCommandBase where Entity : BaseEntity
    {
        private ViewModelCatalogue<Entity> viewModel = null!;

        public LoadRecordListCommand(ViewModelBase parameter)
        {
            viewModel = (ViewModelCatalogue<Entity>)parameter;
        }
        public override async Task ExecuteAsync(object? parameter = null)
        {
            viewModel.IsLoading = true;
            await viewModel.Initialize();
            viewModel.IsLoading = false;
        }
    }
}
