using Domain.Logic.Base;
using MVVMGenericStructure.Commands;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace WPF.Command.Generic
{
    public class DeleteCommand : AsyncCommandBase
    {
        private readonly ILogic logic;

        public DeleteCommand(ILogic parameter)
        {
            logic = parameter;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await logic.Delete((int)parameter);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar el registro.");
            }
        }
    }
}
