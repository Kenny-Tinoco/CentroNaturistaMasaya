using Domain.Entities;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace WPF.Stores
{
    public class EntityStore
    {
        public bool isEdition { get; set; }
        public BaseEntity entity;
        public ObservableCollection<BaseEntity> _catalogue { get; set; }


        public event Action<BaseEntity> EntityCreated;
        public event Action<BaseEntity> EntityEdited;
        public event Action<BaseEntity> EntitySelected;
        public event Action Refresh;

        public void CreateEntity(BaseEntity parameter)
        {
            EntityCreated?.Invoke(parameter);
        }

        public void EditEntity(BaseEntity parameter)
        {
            EntityEdited?.Invoke(parameter);
        }

        public void SelectEntity(BaseEntity parameter)
        {
            EntitySelected.Invoke(parameter);
        }

        public void RefreshChanges()
        {
            Refresh.Invoke();
        }
    }
}
