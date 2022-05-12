using Domain.Entities;
using Domain.Logic;
using MVVMGenericStructure.Commands;
using System.Threading.Tasks;

namespace WPF.Command.CRUD
{
    public class DeleteCommand<Entity> : AsyncCommandBase where Entity : BaseEntity
    {
        private readonly BaseLogic<Entity> logic;

        public DeleteCommand(BaseLogic<Entity> parameter)
        {
            logic = parameter;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await logic.Delete((int)parameter);
        }
    }
}
