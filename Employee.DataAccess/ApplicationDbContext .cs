using Employee.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employees> Employee { get; set; }
        public DbSet<PaymentRecords> PaymentRecord { get; set; }
        public DbSet<TaxYear> TaxYear { get; set; }
    }
}
