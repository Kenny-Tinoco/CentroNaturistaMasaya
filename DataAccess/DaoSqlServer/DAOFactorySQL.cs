using DataAccess.SqlServerDataSource;
using Domain.DAO;

namespace DataAccess.DaoSqlServer
{
    public class DAOFactorySQL : DAOFactory
    {
        private MasayaNaturistCenterDataBaseFactory _contextFactory;

        private AccountDAO _accountDAO = null!;
        private ConsultDAO _consultDAO = null!;
        private EmployeeDAO _employeeDAO = null!;
        private PatientDAO _patientDAO = null!;
        private PrescriptionProductDAO _prescriptionProductDAO = null!;
        private PresentationDAO _presentationDAO = null!;
        private ProductDAO _productDAO = null!;
        private ProviderDAO _providerDAO = null!;
        private ProviderPhoneDAO _providerPhoneDAO = null!;
        private StockDAO _stockDAO = null!;
        private StockKeepingDAO _stockKeepingDAO = null!;
        private SaleDAO _sellDAO = null!;
        private SupplyDAO _supplyDAO = null!;
        private SupplyDetailDAO _supplyDetailDAO = null!;

        public DAOFactorySQL(MasayaNaturistCenterDataBaseFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public override AccountDAO accountDAO
        {
            get
            {
                if (_accountDAO == null)
                    _accountDAO = new AccountDAOSQL(_contextFactory);

                return _accountDAO;
            }
        }

        public override ConsultDAO consultDAO
        {
            get
            {
                if (_consultDAO == null)
                    _consultDAO = new ConsultDAOSQL(_contextFactory);

                return _consultDAO;
            }
        }

        public override EmployeeDAO employeeDAO
        {
            get
            {
                if (_employeeDAO == null)
                    _employeeDAO = new EmployeeDAOSQL(_contextFactory);

                return _employeeDAO;
            }
        }

        public override PatientDAO patientDAO
        {
            get
            {
                if (_patientDAO == null)
                    _patientDAO = new PatientDAOSQL(_contextFactory);

                return _patientDAO;
            }
        }

        public override PrescriptionProductDAO prescriptionProductDAO
        {
            get
            {
                if (_prescriptionProductDAO == null)
                    _prescriptionProductDAO = new PrescriptionProductDAOSQL(_contextFactory);

                return _prescriptionProductDAO;
            }
        }

        public override PresentationDAO presentationDAO
        {
            get
            {
                if (_presentationDAO == null)
                    _presentationDAO = new PresentationDAOSQL(_contextFactory);

                return _presentationDAO;
            }
        }

        public override ProviderDAO providerDAO
        {
            get
            {
                if (_providerDAO == null)
                    _providerDAO = new ProviderDAOSQL(_contextFactory);

                return _providerDAO;
            }
        }

        public override ProviderPhoneDAO providerPhoneDAO
        {
            get
            {
                if (_providerPhoneDAO == null)
                    _providerPhoneDAO = new ProviderPhoneDAOSQL(_contextFactory);

                return _providerPhoneDAO;
            }
        }

        public override ProductDAO productDAO
        {
            get
            {
                if (_productDAO == null)
                    _productDAO = new ProductDAOSQL(_contextFactory);

                return _productDAO;
            }
        }

        public override StockDAO stockDAO
        {
            get 
            {
                if (_stockDAO == null)
                    _stockDAO = new StockDAOSQL(_contextFactory);

                return _stockDAO; 
            }
        }

        public override StockKeepingDAO stockKeepingDAO
        {
            get
            {
                if (_stockKeepingDAO == null)
                    _stockKeepingDAO = new StockKeepingDAOSQL(_contextFactory);

                return _stockKeepingDAO;
            }
        }

        public override SaleDAO sellDAO
        {
            get
            {
                if (_sellDAO == null)
                    _sellDAO = new SaleDAOSQL(_contextFactory);

                return _sellDAO;
            }
        }

        public override SupplyDAO supplyDAO
        {
            get
            {
                if (_supplyDAO == null)
                    _supplyDAO = new SupplyDAOSQL(_contextFactory);

                return _supplyDAO;
            }
        }

        public override SupplyDetailDAO supplyDetailDAO
        {
            get
            {
                if (_supplyDetailDAO == null)
                    _supplyDetailDAO = new SupplyDetailDAOSQL(_contextFactory);

                return _supplyDetailDAO;
            }
        }
    }
}
