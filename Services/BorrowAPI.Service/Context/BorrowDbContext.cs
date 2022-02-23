using BorrowAPI.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace BorrowAPI.Service.Context
{
    public class BorrowDbContext : DbContext
    {
        

        public BorrowDbContext(DbContextOptions<BorrowDbContext> options) : base(options)
        {
        }

        public DbSet<Borrow> Borrows { get; set; }
  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
