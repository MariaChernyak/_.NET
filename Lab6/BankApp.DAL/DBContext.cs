using System.Data.Entity;
using BankApp.Models;

namespace BankApp.DAL
{
    public class DBContext:DbContext
    {
        public DBContext(string connection):base(connection)
        {
            
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<TypeOfBill> TypeOfBills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<BankAccount>().ToTable("BankAccount");
            modelBuilder.Entity<TypeOfBill>().ToTable("TypeOfBill");
            //modelBuilder.Entity<Client>()
            //    .Property(p => p.SecondName)
            //    .HasColumnName("second_name");
            //modelBuilder.Entity<Client>()
            //    .Property(p => p.FirstName)
            //    .HasColumnName("first_name");
            //modelBuilder.Entity<Client>()
            //    .Property(p => p.DateOfBirth)
            //    .HasColumnName("date_of_birth");


            base.OnModelCreating(modelBuilder);
        }
    }
}
