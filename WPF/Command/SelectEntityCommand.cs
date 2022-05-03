using Domain.Entities;
using MVVMGenericStructure.Commands;
using System.Windows;
using WPF.Stores;
using WPF.ViewModel;

namespace WPF.Command
{
    public class SelectEntityCommand : CommandBase
    {
        private readonly EntityStore _entityStore;

        public SelectEntityCommand(EntityStore entityStore)
        {
            _entityStore = entityStore;
        }

        public override void Execute(object _entity)
        {
            _entityStore.SelectEntity((BaseEntity)_entity);
        }
    }
}
