using Domain.Entities;
using MVVMGenericStructure.Commands;
using WPF.Stores;
using WPF.ViewModel.Base;

namespace WPF.Command
{
    public class SaveEntityCommand : CommandBase
    {
        private readonly ModalFormViewModel _viewModel;
        private readonly EntityStore _entityStore;

        public SaveEntityCommand(ModalFormViewModel viewModel, EntityStore entityStore)
        {
            _viewModel = viewModel;
            _entityStore = entityStore;
        }

        public override void Execute(object isEdition)
        {
            BaseEntity _entity = _viewModel.entity;
            _viewModel.ResetEntity();

            if ((bool)isEdition)
            {
                _entityStore.EditEntity(_entity);
                _viewModel.ExitCommand.Execute(null);
            }
            else
                _entityStore.CreateEntity(_entity);
        }
    }
}
