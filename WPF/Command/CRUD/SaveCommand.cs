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

        public override async Task ExecuteAsync( object isUpdateOperation)
        {
            if ((bool)isUpdateOperation)
                await logicElement.Edit();
            else
                await logicElement.Save();
        }
    }
}
