using Domain.Entities;
using System;
using System.Collections.Generic;

namespace WPF.Stores
{
    public class EntityStore
    {
        public bool isEdition { get; set; }
        public BaseEntity entity;
        public IEnumerable<BaseEntity> _catalogue { get; set; }


        public event Action<BaseEntity> EntityCreated;
        public event Action<BaseEntity> EntityEdited;
        public event Action<BaseEntity> EntitySelected;
        public event Action<BaseEntity> EntityDeleted;
        public event Action RefreshStock;
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
            EntitySelected?.Invoke(parameter);
        }
        public void DeleteEntity(BaseEntity parameter)
        {
            EntityDeleted?.Invoke(parameter);
        }

        public void RefreshChanges()
        {
            Refresh.Invoke();
        }
        public void RefreshStockChanges()
        {
            RefreshStock.Invoke();
        }
    }
}
