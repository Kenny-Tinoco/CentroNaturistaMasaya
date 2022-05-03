using Domain.Entities;
using Domain.Logic;
using MVVMGenericStructure.Commands;
using System.Threading.Tasks;

namespace WPF.Command.CRUD
{
    public class SaveCommand<Entity> : AsyncCommandBase where Entity : BaseEntity
    {
        private BaseLogic<Entity> logicElement;
        private bool canSave;

        public SaveCommand( BaseLogic<Entity> parameter, bool _canSave)
        {
            logicElement = parameter;
            canSave = _canSave;
        }

        public override bool CanExecute( object parameter )
        {
            return canSave && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync( object parameter )
        {
            var isUpdateOperation = (bool)parameter;
            if (isUpdateOperation)
                await logicElement.edit();
            else
                await logicElement.save();
        }
    }
}
