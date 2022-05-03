using Domain.Entities;
using Domain.Logic;
using MVVMGenericStructure.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Command.CRUD;

namespace WPF.ViewModel.Base
{
    public class ViewModelCatalogue<Entity> : ViewModelBase where Entity : BaseEntity
    {

        public ViewModelCatalogue(BaseLogic<Entity> logic)
        {
            this.logic = logic;

            LoadCatalogueCommand = new LoadRecordListCommand<Entity>(this);
        }

        protected ICommand LoadCatalogueCommand { get; set; } = null!;

        public async virtual Task Initialize()
        {
            await updateCatalogue();
        }

        private ObservableCollection<Entity> _catalogue;
        public ObservableCollection<Entity> catalogue
        {
            get
            {
                if (_catalogue == null)
                    _catalogue = new ObservableCollection<Entity>();
                return _catalogue;
            }
            set
            {
                _catalogue = value;
                OnPropertyChanged(nameof(catalogue));
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        public BaseLogic<Entity> logic { get; set; }

        protected async Task updateCatalogue()
        {
            RefreshCatalogue(await logic.getAll());
        }

        public void RefreshCatalogue(IEnumerable<Entity> list)
        {
            catalogue.Clear();

            var auxiliaryList = new ObservableCollection<Entity>();
            list.ToList().ForEach(element => auxiliaryList.Add(element));

            catalogue = auxiliaryList;
        }
        protected bool validateSearchString(string parameter)
        {
            return
                !parameter.Trim().Equals("Búscar") &&
                !parameter.Trim().Equals("");
        }

    }
}
