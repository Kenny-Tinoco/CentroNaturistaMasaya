using Domain.Entities;
using Domain.Logic;
using MVVMGenericStructure.Commands;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace WPF.Command.CRUD
{
    public class DeleteCommand<Entity> : AsyncCommandBase where Entity : BaseEntity
    {
        private BaseLogic<Entity> logicElement;

        public DeleteCommand( BaseLogic<Entity> parameter )
        {
            Contract.Requires(parameter != null);
            logicElement = parameter;
        }

        public override async Task ExecuteAsync( object parameter )
        {
            await logicElement.delete((Entity)parameter);
        }
    }
}
