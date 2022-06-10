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

        public MasayaNaturistCenterDataBase(DbContextOptions<MasayaNaturistCenterDataBase> options) : base(options)
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
        public virtual DbSet<SaleDetail> SaleDetails { get; set; } = null!;
        public virtual DbSet<SaleDetailView> SaleDetailViews { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<SaleView> SaleViews { get; set; } = null!;
        public virtual DbSet<Stock> Stocks { get; set; } = null!;
        public virtual DbSet<StockKeeping> StockKeepings { get; set; } = null!;
        public virtual DbSet<StockView> StockViews { get; set; } = null!;
        public virtual DbSet<Supply> Supplies { get; set; } = null!;
        public virtual DbSet<SupplyDetail> SupplyDetails { get; set; } = null!;
        public virtual DbSet<SupplyDetailView> SupplyDetailViews { get; set; } = null!;
        public virtual DbSet<SupplyView> SupplyViews { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.IdAccount)
                    .HasName("PK__Account__DA18132C515BF8B2");

                entity.ToTable("Account");

                entity.Property(e => e.IdAccount).HasColumnName("idAccount");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.Password)
                    .HasColumnType("varbinary")
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account__idEmplo__5629CD9C");
            });

            modelBuilder.Entity<AccountRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AccountRole");

                entity.Property(e => e.IdAccount).HasColumnName("idAccount");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AccountRo__idAcc__5AEE82B9");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AccountRo__idRol__59FA5E80");
            });

            modelBuilder.Entity<Consult>(entity =>
            {
                entity.HasKey(e => e.IdConsult)
                    .HasName("PK__Consult__39F4CA471337D882");

                entity.ToTable("Consult");

                entity.Property(e => e.IdConsult).HasColumnName("idConsult");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.IdPatient).HasColumnName("idPatient");

                entity.Property(e => e.Symptom)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("symptom");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Consults)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consult__idEmplo__4E88ABD4");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.Consults)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consult__idPatie__4F7CD00D");
            });

            modelBuilder.Entity<ConsultView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ConsultView");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(101)
                    .IsUnicode(false)
                    .HasColumnName("employeeName");

                entity.Property(e => e.IdConsult).HasColumnName("idConsult");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.IdPatient).HasColumnName("idPatient");

                entity.Property(e => e.PatientName)
                    .HasMaxLength(101)
                    .IsUnicode(false)
                    .HasColumnName("patientName");

                entity.Property(e => e.Symptom)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("symptom");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PK__Employee__227F26A50788AFCE");

                entity.ToTable("Employee");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient)
                    .HasName("PK__Patient__8C242805FE62B9E2");

                entity.ToTable("Patient");

                entity.Property(e => e.IdPatient).HasColumnName("idPatient");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<PrescriptionProduct>(entity =>
            {
                entity.HasKey(e => e.IdPrescriptionProduct)
                    .HasName("PK__Prescrip__081B6E5C14116B2D");

                entity.ToTable("PrescriptionProduct");

                entity.Property(e => e.IdPrescriptionProduct).HasColumnName("idPrescriptionProduct");

                entity.Property(e => e.IdConsult).HasColumnName("idConsult");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.HasOne(d => d.IdConsultNavigation)
                    .WithMany(p => p.PrescriptionProducts)
                    .HasForeignKey(d => d.IdConsult)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prescript__idCon__52593CB8");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.PrescriptionProducts)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prescript__idPro__534D60F1");
            });

            modelBuilder.Entity<PrescriptionProductView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PrescriptionProductView");

                entity.Property(e => e.IdPrescriptionProduct).HasColumnName("idPrescriptionProduct");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("productName");
            });

            modelBuilder.Entity<Presentation>(entity =>
            {
                entity.HasKey(e => e.IdPresentation)
                    .HasName("PK__Presenta__A3EA35C100ECE0C5");

                entity.ToTable("Presentation");

                entity.Property(e => e.IdPresentation).HasColumnName("idPresentation");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Product__5EEC79D1FE0B6F14");

                entity.ToTable("Product");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.IdProvider)
                    .HasName("PK__Provider__CFAFC10F53051C1E");

                entity.ToTable("Provider");

                entity.HasIndex(e => e.Ruc, "UQ__Provider__C2B74E615C9EB988")
                    .IsUnique();

                entity.Property(e => e.IdProvider).HasColumnName("idProvider");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Ruc)
                    .HasMaxLength(30)
                    .HasColumnName("ruc");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<ProviderPhone>(entity =>
            {
                entity.HasKey(e => e.IdProviderPhone)
                    .HasName("PK__Provider__FB3598A1030B7A65");

                entity.ToTable("ProviderPhone");

                entity.Property(e => e.IdProviderPhone).HasColumnName("idProviderPhone");

                entity.Property(e => e.IdProvider).HasColumnName("idProvider");

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .HasColumnName("phone");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.ProviderPhones)
                    .HasForeignKey(d => d.IdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProviderP__idPro__38996AB5");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__Role__E5045C54D2A1DFF8");

                entity.ToTable("Role");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<SaleDetail>(entity =>
            {
                entity.HasKey(e => e.IdSaleDetail)
                     .HasName("PK__SaleDeta__B23385CD29B46516");

                entity.ToTable("SaleDetail");

                entity.Property(e => e.IdSaleDetail).HasColumnName("idSaleDetail");

                entity.Property(e => e.IdSale).HasColumnName("idSell");

                entity.Property(e => e.IdStock).HasColumnName("idStock");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdSellNavigation)
                    .WithMany(p => p.SaleDetails)
                    .HasForeignKey(d => d.IdSale)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SaleDetai__idSel__412EB0B6");
            });

            modelBuilder.Entity<SaleDetailView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SaleDetailView");

                entity.Property(e => e.IdSaleDetail).HasColumnName("idSaleDetail");

                entity.Property(e => e.IdSale).HasColumnName("idSell");
                entity.Property(e => e.IdStock).HasColumnName("idStock");

                entity.Property(e => e.Presentation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("presentation");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("productDescription");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("productName");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Total).HasColumnName("total");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.IdSale)
                .HasName("PK__Sell__C5AEA0D398F35ACB");

                entity.ToTable("Sell");

                entity.Property(e => e.IdSale).HasColumnName("idSell");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Sells)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sell__idEmployee__30F848ED");
            });

            modelBuilder.Entity<SaleView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SellView");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.IdSale).HasColumnName("idSell");

                entity.Property(e => e.Name)
                    .HasMaxLength(101)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Total).HasColumnName("total");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.IdStock)
                    .HasName("PK__Stock__A4B76DE5F42DC7EE");

                entity.ToTable("Stock");

                entity.Property(e => e.IdStock).HasColumnName("idStock");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("entryDate");

                entity.Property(e => e.Expiration)
                    .HasColumnType("datetime")
                    .HasColumnName("expiration");

                entity.Property(e => e.IdPresentation).HasColumnName("idPresentation");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.Image)
                    .HasColumnType("image")
                    .HasColumnName("image");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.PresentationNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.IdPresentation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stock__idPresent__3C69FB99");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stock__idProduct__3B75D760");

            });

            modelBuilder.Entity<StockView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("StockView");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("entryDate");

                entity.Property(e => e.Expiration)
                    .HasColumnType("datetime")
                    .HasColumnName("expiration");

                entity.Property(e => e.IdStock).HasColumnName("idStock");

                entity.Property(e => e.Image)
                    .HasColumnType("image")
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Presentation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("presentation");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<StockKeeping>(entity =>
            {
                entity.HasKey(e => e.IdStockKeeping)
                    .HasName("PK__StockKee__5B547A51DF70EFAA");

                entity.ToTable("StockKeeping");

                entity.Property(e => e.IdStock).HasColumnName("idStock");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Concept).HasColumnName("concept");

            });

            modelBuilder.Entity<Supply>(entity =>
            {
                entity.HasKey(e => e.IdSupply)
                    .HasName("PK__Supply__E94C363742BAFE36");

                entity.ToTable("Supply");

                entity.Property(e => e.IdSupply).HasColumnName("idSupply");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.IdProvider).HasColumnName("idProvider");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.IdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Supply__idProvid__34C8D9D1");
            });

            modelBuilder.Entity<SupplyDetail>(entity =>
            {
                entity.HasKey(e => e.IdSupplyDetail)
                    .HasName("PK__SupplyDe__B6029C4B59C433B3");

                entity.ToTable("SupplyDetail");

                entity.Property(e => e.IdSupplyDetail).HasColumnName("idSupplyDetail");

                entity.Property(e => e.IdStock).HasColumnName("idStock");

                entity.Property(e => e.IdSupply).HasColumnName("idSupply");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Total).HasColumnName("total");


                entity.HasOne(d => d.IdSupplyNavigation)
                    .WithMany(p => p.SupplyDetails)
                    .HasForeignKey(d => d.IdSupply)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SupplyDet__idSup__47DBAE45");
            });

            modelBuilder.Entity<SupplyDetailView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SupplyDetailView");

                entity.Property(e => e.IdStock).HasColumnName("idStock");
                entity.Property(e => e.IdSupply).HasColumnName("idSupply");

                entity.Property(e => e.IdSupplyDetail).HasColumnName("idSupplyDetail");

                entity.Property(e => e.Presentation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("presentation");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("productDescription");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("productName");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Total).HasColumnName("total");
            });

            modelBuilder.Entity<SupplyView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SupplyView");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.IdProvider).HasColumnName("idProvider");

                entity.Property(e => e.IdSupply).HasColumnName("idSupply");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("providerName");

                entity.Property(e => e.Total).HasColumnName("total");
                entity.Property(e => e.Discount).HasColumnName("discount");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
