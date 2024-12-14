using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarDealership;

public partial class CarDealershipMainContext : DbContext
{
    public CarDealershipMainContext()
    {
    }

    public CarDealershipMainContext(DbContextOptions<CarDealershipMainContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BodyType> BodyTypes { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarBrand> CarBrands { get; set; }

    public virtual DbSet<Credit> Credits { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<DriveType> DriveTypes { get; set; }

    public virtual DbSet<EngineType> EngineTypes { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Modification> Modifications { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceSale> ServiceSales { get; set; }

    public virtual DbSet<TransmissionType> TransmissionTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CarDealershipMain;Username=postgres;Password=database789");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BodyType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("body_type_pkey");

            entity.ToTable("body_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("booking_pkey");

            entity.ToTable("booking");

            entity.HasIndex(e => e.CarId, "fki_car_fk");

            entity.HasIndex(e => e.CustomerId, "fki_customer_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CarId).HasColumnName("car_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Date).HasColumnName("date");

            entity.HasOne(d => d.Car).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("car_fk");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customer_fk");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("car_pkey");

            entity.ToTable("car");

            entity.HasIndex(e => e.ModificationId, "fki_modification_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountryProduction)
                .HasMaxLength(100)
                .HasColumnName("country_production");
            entity.Property(e => e.ModificationId).HasColumnName("modification_id");
            entity.Property(e => e.ReleaseYear).HasColumnName("release_year");
            entity.Property(e => e.Vin)
                .HasMaxLength(100)
                .HasColumnName("VIN");

            entity.HasOne(d => d.Modification).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ModificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("modification_fk");
        });

        modelBuilder.Entity<CarBrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("car_brand_pkey");

            entity.ToTable("car_brand");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Credit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("credit_pkey");

            entity.ToTable("credit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.InterestRate).HasColumnName("interest_rate");
            entity.Property(e => e.Period).HasColumnName("period");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customer_pkey");

            entity.ToTable("customer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FisrtName)
                .HasMaxLength(100)
                .HasColumnName("fisrt_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.ThirdName)
                .HasMaxLength(100)
                .HasColumnName("third_name");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("discount_pkey");

            entity.ToTable("discount");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Percentage).HasColumnName("percentage");
        });

        modelBuilder.Entity<DriveType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("drive_type_pkey");

            entity.ToTable("drive_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<EngineType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("engine_type_pkey");

            entity.ToTable("engine_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("model_pkey");

            entity.ToTable("model");

            entity.HasIndex(e => e.CarBrandId, "fki_car_brand_fk");

            entity.HasIndex(e => e.DiscountId, "fki_discount_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CarBrandId).HasColumnName("car_brand_id");
            entity.Property(e => e.DateReceipt).HasColumnName("date_receipt");
            entity.Property(e => e.DiscountId).HasColumnName("discount_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.StockCuantity).HasColumnName("stock_cuantity");
            entity.Property(e => e.Image).HasColumnName("image");

            entity.HasOne(d => d.CarBrand).WithMany(p => p.Models)
                .HasForeignKey(d => d.CarBrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("car_brand_fk");

            entity.HasOne(d => d.Discount).WithMany(p => p.Models)
                .HasForeignKey(d => d.DiscountId)
                .HasConstraintName("discount_fk");
        });

        modelBuilder.Entity<Modification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("modification_pkey");

            entity.ToTable("modification");

            entity.HasIndex(e => e.BodyTypeId, "fki_body_type_fk");

            entity.HasIndex(e => e.DriveTypeId, "fki_drive_type_fk");

            entity.HasIndex(e => e.EngineTypeId, "fki_engine_type_fk");

            entity.HasIndex(e => e.ModelId, "fki_model_fk");

            entity.HasIndex(e => e.TransmissionTypeId, "fki_transmission_type_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BodyTypeId).HasColumnName("body_type_id");
            entity.Property(e => e.DriveTypeId).HasColumnName("drive_type_id");
            entity.Property(e => e.EngineCapacity).HasColumnName("engine_capacity");
            entity.Property(e => e.EngineTypeId).HasColumnName("engine_type_id");
            entity.Property(e => e.Horsepower).HasColumnName("horsepower");
            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.TransmissionTypeId).HasColumnName("transmission_type_id");

            entity.HasOne(d => d.BodyType).WithMany(p => p.Modifications)
                .HasForeignKey(d => d.BodyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("body_type_fk");

            entity.HasOne(d => d.DriveType).WithMany(p => p.Modifications)
                .HasForeignKey(d => d.DriveTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("drive_type_fk");

            entity.HasOne(d => d.EngineType).WithMany(p => p.Modifications)
                .HasForeignKey(d => d.EngineTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("engine_type_fk");

            entity.HasOne(d => d.Model).WithMany(p => p.Modifications)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("model_fk");

            entity.HasOne(d => d.TransmissionType).WithMany(p => p.Modifications)
                .HasForeignKey(d => d.TransmissionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transmission_type_fk");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payment_pkey");

            entity.ToTable("payment");

            entity.HasIndex(e => e.SaleId, "fki_sale_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");

            entity.HasOne(d => d.Sale).WithMany(p => p.Payments)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sale_fk");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sale_pkey");

            entity.ToTable("sale");

            entity.HasIndex(e => e.CreditId, "fki_credit_fk");

            entity.HasIndex(e => e.SellerId, "fki_seller_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CarId).HasColumnName("car_id");
            entity.Property(e => e.CarPrice).HasColumnName("car_price");
            entity.Property(e => e.CreditId).HasColumnName("credit_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.SaleDate).HasColumnName("sale_date");
            entity.Property(e => e.SellerId).HasColumnName("seller_id");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");

            entity.HasOne(d => d.Car).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("car_fk");

            entity.HasOne(d => d.Credit).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CreditId)
                .HasConstraintName("credit_fk");

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customer_fk");

            entity.HasOne(d => d.Seller).WithMany(p => p.Sales)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("seller_fk");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("seller_pkey");

            entity.ToTable("seller");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.ThirdName)
                .HasMaxLength(100)
                .HasColumnName("third_name");
            entity.Property(e => e.WorkExperience).HasColumnName("work_experience");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("service_pkey");

            entity.ToTable("service");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<ServiceSale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("service_sale_pkey");

            entity.ToTable("service_sale");

            entity.HasIndex(e => e.ServiceId, "fki_service_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.ServicePrice).HasColumnName("service_price");

            entity.HasOne(d => d.Sale).WithMany(p => p.ServiceSales)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sale_fk");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceSales)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("service_fk");
        });

        modelBuilder.Entity<TransmissionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("transmission_type_pkey");

            entity.ToTable("transmission_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
