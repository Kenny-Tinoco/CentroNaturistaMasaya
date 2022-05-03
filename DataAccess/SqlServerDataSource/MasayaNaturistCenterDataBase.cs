using Domain.Entities;
using Domain.Entities.Views;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.SqlServerDataSource
{
    public partial class MasayaNaturistCenterDataBase : DbContext
    {
        public MasayaNaturistCenterDataBase()
        {
        }

        public MasayaNaturistCenterDataBase(DbContextOptions<MasayaNaturistCenterDataBase> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountRole> AccountRoles { get; set; } = null!;
        public virtual DbSet<Consult> Consults { get; set; } = null!;
        public virtual DbSet<ConsultView> ConsultViews { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<PrescriptionProduct> PrescriptionProducts { get; set; } = null!;
        public virtual DbSet<PrescriptionProductView> PrescriptionProductViews { get; set; } = null!;
        public virtual DbSet<Presentation> Presentations { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<ProviderPhone> ProviderPhones { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TransactionDetail> SaleDetails { get; set; } = null!;
        public virtual DbSet<SaleDetailView> SaleDetailViews { get; set; } = null!;
        public virtual DbSet<Transaction> Sells { get; set; } = null!;
        public virtual DbSet<SellView> SellViews { get; set; } = null!;
        public virtual DbSet<Stock> Stocks { get; set; } = null!;
        public virtual DbSet<StockView> StockViews { get; set; } = null!;
        public virtual DbSet<Transaction> Supplies { get; set; } = null!;
        public virtual DbSet<TransactionDetail> SupplyDetails { get; set; } = null!;
        public virtual DbSet<SupplyDetailView> SupplyDetailViews { get; set; } = null!;
        public virtual DbSet<SupplyView> SupplyViews { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.idAccount)
                    .HasName("PK__Account__DA18132CA168B70C");

                entity.ToTable("Account");

                entity.Property(e => e.idAccount).HasColumnName("idAccount");

                entity.Property(e => e.created)
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.idEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.userName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<AccountRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AccountRole");

                entity.Property(e => e.idAccount).HasColumnName("idAccount");

                entity.Property(e => e.idRole).HasColumnName("idRole");
            });

            modelBuilder.Entity<Consult>(entity =>
            {
                entity.HasKey(e => e.idConsult)
                    .HasName("PK__Consult__39F4CA478675F0EB");

                entity.ToTable("Consult");

                entity.Property(e => e.idConsult).HasColumnName("idConsult");

                entity.Property(e => e.date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.idEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.idPatient).HasColumnName("idPatient");

                entity.Property(e => e.symptom)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("symptom");
            });

            modelBuilder.Entity<ConsultView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ConsultView");

                entity.Property(e => e.date)
                    .HasMaxLength(4000)
                    .HasColumnName("date");

                entity.Property(e => e.employeeName)
                    .HasMaxLength(101)
                    .IsUnicode(false)
                    .HasColumnName("employeeName");

                entity.Property(e => e.idConsult).HasColumnName("idConsult");

                entity.Property(e => e.idEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.idPatient).HasColumnName("idPatient");

                entity.Property(e => e.patientName)
                    .HasMaxLength(101)
                    .IsUnicode(false)
                    .HasColumnName("patientName");

                entity.Property(e => e.symptom)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("symptom");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.idEmployee)
                    .HasName("PK__Employee__227F26A55E02BD69");

                entity.ToTable("Employee");

                entity.Property(e => e.idEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.lastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.idPatient)
                    .HasName("PK__Patient__8C242805556FBD68");

                entity.ToTable("Patient");

                entity.Property(e => e.idPatient).HasColumnName("idPatient");

                entity.Property(e => e.address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.age).HasColumnName("age");

                entity.Property(e => e.lastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PrescriptionProduct>(entity =>
            {
                entity.HasKey(e => e.idPrescriptionProduct)
                    .HasName("PK__Prescrip__081B6E5CFD02485A");

                entity.ToTable("PrescriptionProduct");

                entity.Property(e => e.idPrescriptionProduct).HasColumnName("idPrescriptionProduct");

                entity.Property(e => e.idConsult).HasColumnName("idConsult");

                entity.Property(e => e.idProduct).HasColumnName("idProduct");
            });

            modelBuilder.Entity<PrescriptionProductView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PrescriptionProductView");

                entity.Property(e => e.idPrescriptionProduct).HasColumnName("idPrescriptionProduct");

                entity.Property(e => e.idProduct).HasColumnName("idProduct");

                entity.Property(e => e.productName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("productName");
            });

            modelBuilder.Entity<Presentation>(entity =>
            {
                entity.HasKey(e => e.idPresentation)
                    .HasName("PK__Presenta__A3EA35C1F80BFD4C");

                entity.ToTable("Presentation");

                entity.Property(e => e.idPresentation).HasColumnName("idPresentation");

                entity.Property(e => e.name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.idProduct)
                    .HasName("PK__Product__5EEC79D12730F083");

                entity.ToTable("Product");

                entity.Property(e => e.idProduct).HasColumnName("idProduct");

                entity.Property(e => e.description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.idProvider)
                    .HasName("PK__Provider__CFAFC10FF1E67E61");

                entity.ToTable("Provider");

                entity.HasIndex(e => e.ruc, "UQ__Provider__C2B74E61D5E7B176")
                    .IsUnique();

                entity.Property(e => e.idProvider).HasColumnName("idProvider");

                entity.Property(e => e.address)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.ruc)
                    .HasMaxLength(30)
                    .HasColumnName("ruc");
            });

            modelBuilder.Entity<ProviderPhone>(entity =>
            {
                entity.HasKey(e => e.idProviderPhone)
                    .HasName("PK__Provider__FB3598A1EDD4DA0A");

                entity.ToTable("ProviderPhone");

                entity.Property(e => e.idProviderPhone).HasColumnName("idProviderPhone");

                entity.Property(e => e.idProvider).HasColumnName("idProvider");

                entity.Property(e => e.phone)
                    .HasMaxLength(12)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.idRole)
                    .HasName("PK__Role__E5045C544F2F9A40");

                entity.ToTable("Role");

                entity.Property(e => e.idRole).HasColumnName("idRole");

                entity.Property(e => e.name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TransactionDetail>(entity =>
            {
                entity.HasKey(e => e.idTransactionDetail)
                    .HasName("PK__SaleDeta__B23385CD97B734AE");

                entity.ToTable("SaleDetail");

                entity.Property(e => e.idTransactionDetail).HasColumnName("idSaleDetail");

                entity.Property(e => e.idTransaction).HasColumnName("idSell");

                entity.Property(e => e.idStock).HasColumnName("idStock");

                entity.Property(e => e.price).HasColumnName("price");

                entity.Property(e => e.quantity).HasColumnName("quantity");

                entity.Property(e => e.total).HasColumnName("total");
            });

            modelBuilder.Entity<SaleDetailView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SaleDetailView");

                entity.Property(e => e.idSaleDetail).HasColumnName("idSaleDetail");

                entity.Property(e => e.idStock).HasColumnName("idStock");

                entity.Property(e => e.presentation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("presentation");

                entity.Property(e => e.price).HasColumnName("price");

                entity.Property(e => e.productDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("productDescription");

                entity.Property(e => e.productName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("productName");

                entity.Property(e => e.quantity).HasColumnName("quantity");

                entity.Property(e => e.total).HasColumnName("total");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.idTransaction)
                    .HasName("PK__Sell__C5AEA0D36E35A861");

                entity.ToTable("Sell");

                entity.Property(e => e.idTransaction).HasColumnName("idSell");

                entity.Property(e => e.date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.idRelatedObjet).HasColumnName("idEmployee");

                entity.Property(e => e.total).HasColumnName("total");
            });

            modelBuilder.Entity<SellView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SellView");

                entity.Property(e => e.date)
                    .HasMaxLength(4000)
                    .HasColumnName("date");

                entity.Property(e => e.idEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.idSell).HasColumnName("idSell");

                entity.Property(e => e.name)
                    .HasMaxLength(101)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.total).HasColumnName("total");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.idStock)
                    .HasName("PK__Stock__A4B76DE569C68715");

                entity.ToTable("Stock");

                entity.Property(e => e.idStock).HasColumnName("idStock");

                entity.Property(e => e.entryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("entryDate");

                entity.Property(e => e.expiration)
                    .HasColumnType("datetime")
                    .HasColumnName("expiration");

                entity.Property(e => e.idPresentation).HasColumnName("idPresentation");

                entity.Property(e => e.idProduct).HasColumnName("idProduct");

                entity.Property(e => e.price).HasColumnName("price");

                entity.Property(e => e.quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<StockView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("StockView");

                entity.Property(e => e.description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.entryDate)
                    .HasMaxLength(4000)
                    .HasColumnName("entryDate");

                entity.Property(e => e.expiration)
                    .HasMaxLength(4000)
                    .HasColumnName("expiration");

                entity.Property(e => e.idStock).HasColumnName("idStock");

                entity.Property(e => e.name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.presentation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("presentation");

                entity.Property(e => e.price).HasColumnName("price");

                entity.Property(e => e.quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.idTransaction)
                    .HasName("PK__Supply__E94C3637E4F27BE9");

                entity.ToTable("Supply");

                entity.Property(e => e.idTransaction).HasColumnName("idSupply");

                entity.Property(e => e.date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.idRelatedObjet).HasColumnName("idProvider");

                entity.Property(e => e.total).HasColumnName("total");
            });

            modelBuilder.Entity<TransactionDetail>(entity =>
            {
                entity.HasKey(e => e.idTransactionDetail)
                    .HasName("PK__SupplyDe__B6029C4B35C5A282");

                entity.ToTable("SupplyDetail");

                entity.Property(e => e.idTransactionDetail).HasColumnName("idSupplyDetail");

                entity.Property(e => e.idStock).HasColumnName("idStock");

                entity.Property(e => e.idTransaction).HasColumnName("idSupply");

                entity.Property(e => e.price).HasColumnName("price");

                entity.Property(e => e.quantity).HasColumnName("quantity");

                entity.Property(e => e.total).HasColumnName("total");
            });

            modelBuilder.Entity<SupplyDetailView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SupplyDetailView");

                entity.Property(e => e.idStock).HasColumnName("idStock");

                entity.Property(e => e.idSupplyDetail).HasColumnName("idSupplyDetail");

                entity.Property(e => e.presentation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("presentation");

                entity.Property(e => e.price).HasColumnName("price");

                entity.Property(e => e.productDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("productDescription");

                entity.Property(e => e.productName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("productName");

                entity.Property(e => e.quantity).HasColumnName("quantity");

                entity.Property(e => e.total).HasColumnName("total");
            });

            modelBuilder.Entity<SupplyView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SupplyView");

                entity.Property(e => e.date)
                    .HasMaxLength(4000)
                    .HasColumnName("date");

                entity.Property(e => e.idProvider).HasColumnName("idProvider");

                entity.Property(e => e.idSupply).HasColumnName("idSupply");

                entity.Property(e => e.providerName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("providerName");

                entity.Property(e => e.total).HasColumnName("total");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
