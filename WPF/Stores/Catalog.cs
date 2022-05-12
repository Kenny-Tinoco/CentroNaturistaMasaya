using Domain.Entities;
using Domain.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WPF.Stores
{
    public struct Catalog
    {
        public LogicFactory logicFactory;

        private Task<IEnumerable<Stock>> _stocks;
        public Task<IEnumerable<Stock>> stocks
        {
            get
            {
                if (_stocks is null)
                    _stocks = logicFactory.stockLogic.GetAll();
                
                return _stocks;
            }
            private set
            {
                _stocks = value;
            }
        }

        public void refreshAll()
        {
            _stocks = null;
        }
    }
}
