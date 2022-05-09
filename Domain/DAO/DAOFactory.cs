namespace Domain.DAO
{
    public abstract class DAOFactory
    {
        public virtual ConsultDAO consultDAO { get; } = null!;
        public virtual EmployeeDAO employeeDAO { get; } = null!;
        public virtual PatientDAO patientDAO { get; } = null!;
        public virtual PrescriptionProductDAO prescriptionProductDAO { get; } = null!;
        public virtual PresentationDAO presentationDAO { get; } = null!;
        public virtual ProductDAO productDAO { get; } = null!;
        public virtual ProviderDAO providerDAO { get; } = null!;
        public virtual StockDAO stockDAO { get; } = null!;
        public virtual SellDAO sellDAO { get; } = null!;
        public virtual SaleDetailDAO saleDetailDAO { get; } = null!;
        public virtual SupplyDAO supplyDAO { get; } = null!;
        public virtual SupplyDetailDAO supplyDetailDAO { get; } = null!;
    }
}
