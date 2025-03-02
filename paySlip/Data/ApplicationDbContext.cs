using Microsoft.EntityFrameworkCore;
using paySlip.Models;

namespace paySlip.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<StudentFee> StudentFees { get; set; }
    }
}
