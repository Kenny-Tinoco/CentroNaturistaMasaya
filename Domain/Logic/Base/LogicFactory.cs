using Domain.DAO;
using Domain.Logic.Base;
using Domain.Services;

namespace Domain.Logic
{
    public class LogicFactory
    {
        private readonly DAOFactory _daoFactory;
        private StockLogic? _stockLogic;
        private SaleLogic? _saleLogic;
        private ProductLogic? _productLogic;
        private ProviderLogic? _providerLogic;
        private EmployeeLogic? _employeeLogic;
        private ProviderPhoneLogic? _providerPhoneLogic;
        private PresentationLogic? _presentationModalLogic;

        public IViewsCollections viewsCollections = null!;
        public LogicFactory(DAOFactory parameter, IViewsCollections _viewsCollections) : this(parameter)
        {
            if(_viewsCollections != null)
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

        public SaleLogic saleLogic
        {
            get
            {
                if (_saleLogic == null)
                    _saleLogic = new SaleLogic(_daoFactory, viewsCollections);
                return _saleLogic;
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

        public ProviderPhoneLogic providerPhoneLogic
        {
            get
            {
                if (_providerPhoneLogic == null)
                    _providerPhoneLogic = new ProviderPhoneLogic(_daoFactory);
                return _providerPhoneLogic;
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

        public ProviderLogic providerLogic
        {
            get
            {
                if (_providerLogic == null)
                    _providerLogic = new ProviderLogic(_daoFactory);
                return _providerLogic;
            }
        }

        public EmployeeLogic employeeLogic
        {
            get
            {
                if (_employeeLogic == null)
                    _employeeLogic = new EmployeeLogic(_daoFactory);
                return _employeeLogic;
            }
        }
    }
}
