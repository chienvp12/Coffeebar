using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Coffee.Entities
{
    public partial class BARContext : DbContext
    {
        public BARContext()
        {
        }

        public BARContext(DbContextOptions<BARContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<BookedTable> BookedTables { get; set; } = null!;
        public virtual DbSet<CoffeeBar> CoffeeBars { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Drink> Drinks { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Table> Tables { get; set; } = null!;
        public virtual DbSet<UserDrink> UserDrinks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-APSSORB\\SERVER_01;Initial Catalog=BAR;User ID=sa;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bill");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OrderID");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Bill__EmployeeID__33D4B598");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Bill__OrderID__34C8D9D1");
            });

            modelBuilder.Entity<BookedTable>(entity =>
            {
                entity.ToTable("BookedTable");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Checkin).HasColumnType("date");

                entity.Property(e => e.Checkout).HasColumnType("date");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OrderID");

                entity.Property(e => e.TableId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TableID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.BookedTables)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__BookedTab__Order__3B75D760");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.BookedTables)
                    .HasForeignKey(d => d.TableId)
                    .HasConstraintName("FK__BookedTab__Table__3C69FB99");
            });

            modelBuilder.Entity<CoffeeBar>(entity =>
            {
                entity.ToTable("CoffeeBar");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Hotline)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Drink>(entity =>
            {

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);


                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.CoffeeBarId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CoffeeBarID");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .IsUnicode(false);


                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.CoffeeBar)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CoffeeBarId)
                    .HasConstraintName("FK__Employee__Coffee__2D27B809");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CustomerID");

                entity.Property(e => e.DateCreate).HasColumnType("date");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Order__CustomerI__30F848ED");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Order__EmployeeI__300424B4");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("Table");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.CoffeeBarId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CoffeeBarID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.CoffeeBar)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.CoffeeBarId)
                    .HasConstraintName("FK__Table__CoffeeBar__267ABA7A");
            });

            modelBuilder.Entity<UserDrink>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.DrinkId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DrinkID");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OrderID");

                entity.HasOne(d => d.Drink)
                    .WithMany(p => p.UserDrinks)
                    .HasForeignKey(d => d.DrinkId)
                    .HasConstraintName("FK__UserDrink__Drink__37A5467C");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.UserDrinks)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__UserDrink__Order__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
