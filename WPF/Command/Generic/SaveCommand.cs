using Domain.Entities;
using Domain.Logic.Base;
using MVVMGenericStructure.Commands;
using System;
using System.Threading.Tasks;
using WPF.ViewModel.Base;

namespace WPF.Command.Generic
{
    public class SaveCommand : AsyncCommandBase
    {
        private readonly ILogic logic;
        private readonly FormViewModel viewModel;

        public SaveCommand( ILogic parameter, FormViewModel _viewModel = null)
        {
            logic = parameter;
            viewModel = _viewModel;

            if (viewModel == null)
                viewModel = new FormViewModel();
        }

        public override bool CanExecute( object parameter )
        {
            return viewModel.canCreate && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object isUpdateOperation)
        {
            viewModel.statusMessage = string.Empty;

            if ((bool)isUpdateOperation)
            {
                try
                {
                    await logic.Edit();
                    viewModel.statusMessage = "Cambios guardados correctamente";
                }
                catch(Exception)
                {
                    viewModel.statusMessage = "Fallo la operción de edición";
                }
            }
            else
            {
                try
                {
                    await logic.Create();
                    viewModel.statusMessage = "Creación exitosa";
                }
                catch (Exception)
                {
                    viewModel.statusMessage = "Fallo la operción de agregar";
                }
            }
        }
    }
}
