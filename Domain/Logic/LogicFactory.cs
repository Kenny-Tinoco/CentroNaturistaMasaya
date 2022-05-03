using Domain.DAO;
using Domain.Services;

namespace Domain.Logic
{
    public class LogicFactory
    {
        private readonly DAOFactory _daoFactory;
        private StockLogic _stockLogic;
        private ProductLogic _productLogic;
        private StockModalLogic _stockModalLogic;
        private PresentationLogic _presentationModalLogic;

        public IViewsCollections viewsCollections;
        public LogicFactory(DAOFactory parameter, IViewsCollections _viewsCollections) : this(parameter)
        {
            viewsCollections = _viewsCollections;
        }
        public LogicFactory( DAOFactory daoFactory )
        {
            _daoFactory = daoFactory;
        }

        public StockLogic stockLogic
        {
            get
            {
                if (_stockLogic == null)
                    _stockLogic = new StockLogic(_daoFactory, viewsCollections);
                return _stockLogic;
            }
        }

        public ProductLogic productLogic
        {
            get
            {
                if (_productLogic == null)
                    _productLogic = new ProductLogic(_daoFactory);
                return _productLogic;
            }
        }

        public StockModalLogic stockModalLogic
        {
            get
            {
                if (_stockModalLogic == null)
                    _stockModalLogic = new StockModalLogic(_daoFactory);
                return _stockModalLogic;
            }
        }
        
        public PresentationLogic presentationModalLogic
        {
            get
            {
                if (_presentationModalLogic == null)
                    _presentationModalLogic = new PresentationLogic(_daoFactory);
                return _presentationModalLogic;
            }
        }
    }
}
