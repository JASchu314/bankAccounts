using Microsoft.EntityFrameworkCore;
namespace bankAccounts.Models
{
    public class bankAccountsContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public bankAccountsContext(DbContextOptions<bankAccountsContext> options) : base(options) { }

	public DbSet<User> users {get; set;}
    	public DbSet<Transaction> Transactions {get; set;}
    }
}