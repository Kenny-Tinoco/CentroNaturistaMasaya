using Domain.DAO;
using Domain.Logic.Base;
using Domain.Services;

namespace Domain.Logic
{
    public class LogicFactory
    {
        private readonly DAOFactory _daoFactory;
        private StockLogic? _stockLogic;
        private StockKeepingLogic? _stockKeepingLogic;
        private SaleLogic? _saleLogic;
        private StockViewerLogic? _stockViewerLogic;
        private ProductLogic? _productLogic;
        private ProviderLogic? _providerLogic;
        private EmployeeLogic? _employeeLogic;
        private ProviderPhoneLogic? _providerPhoneLogic;
        private PresentationLogic? _presentationModalLogic;
        private PurchaseLogic? _purchaseLogic;

        public IViewsCollections viewsCollections = null!;
        public LogicFactory(DAOFactory parameter, IViewsCollections _viewsCollections) : this(parameter)
        {
            if(_viewsCollections is not null)
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
                if (_stockLogic is null)
                    _stockLogic = new StockLogic(_daoFactory, viewsCollections);
                return _stockLogic;
            }
        }

        public StockKeepingLogic stockKeepingLogic
        {
            get
            {
                if (_stockKeepingLogic is null)
                    _stockKeepingLogic = new StockKeepingLogic(_daoFactory);
                return _stockKeepingLogic;
            }
        }


        public StockViewerLogic stockViewerLogic
        {
            get
            {
                if (_stockViewerLogic is null)
                    _stockViewerLogic = new StockViewerLogic(_daoFactory, viewsCollections);
                return _stockViewerLogic;
            }
        }

        public SaleLogic saleLogic
        {
            get
            {
                if (_saleLogic is null)
                    _saleLogic = new SaleLogic(_daoFactory, viewsCollections);
                return _saleLogic;
            }
        }

        public ProductLogic productLogic
        {
            get
            {
                if (_productLogic is null)
                    _productLogic = new ProductLogic(_daoFactory);
                return _productLogic;
            }
        }

        public ProviderPhoneLogic providerPhoneLogic
        {
            get
            {
                if (_providerPhoneLogic is null)
                    _providerPhoneLogic = new ProviderPhoneLogic(_daoFactory);
                return _providerPhoneLogic;
            }
        }
        
        public PresentationLogic presentationModalLogic
        {
            get
            {
                if (_presentationModalLogic is null)
                    _presentationModalLogic = new PresentationLogic(_daoFactory);
                return _presentationModalLogic;
            }
        }

        public ProviderLogic providerLogic
        {
            get
            {
                if (_providerLogic is null)
                    _providerLogic = new ProviderLogic(_daoFactory);
                return _providerLogic;
            }
        }

        public EmployeeLogic employeeLogic
        {
            get
            {
                if (_employeeLogic is null)
                    _employeeLogic = new EmployeeLogic(_daoFactory);
                return _employeeLogic;
            }
        }

        public PurchaseLogic purchaseLogic
        {
            get
            {
                if (_purchaseLogic is null)
                    _purchaseLogic = new PurchaseLogic(_daoFactory, viewsCollections);
                return _purchaseLogic;
            }
        }
    }
}
