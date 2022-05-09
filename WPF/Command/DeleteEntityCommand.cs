using Domain.Entities;
using MVVMGenericStructure.Commands;
using WPF.Stores;
using WPF.ViewModel.Base;

namespace WPF.Command
{
    public class DeleteEntityCommand : CommandBase
    {
        private readonly ModalFormViewModel _viewModel;
        private readonly EntityStore _entityStore;

        public DeleteEntityCommand(ModalFormViewModel viewModel, EntityStore entityStore)
        {
            _viewModel = viewModel;
            _entityStore = entityStore;
        }

        public override void Execute(object parameter = null)
        {
            BaseEntity _entity = _viewModel.entity;
            _viewModel.ResetEntity();

            _entityStore.DeleteEntity(_entity);
            _viewModel.ExitCommand.Execute(null);
        }
    }
}
