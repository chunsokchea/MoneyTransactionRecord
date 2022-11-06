using Microsoft.EntityFrameworkCore;
using MoneyTransferWeb.Models;

namespace MoneyTransferWeb.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
        }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<TransactionChild> TransactionChilds { get; set; }
        public virtual DbSet<Capital> Capitals { get; set; }
        public virtual DbSet<Balance> Balances { get; set; }       
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<ReturnTransaction> Returns { get; set; }
        public virtual DbSet<Withdraw> Withdraws { get; set; }
        public virtual DbSet<Debt> Debts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
    }
}
