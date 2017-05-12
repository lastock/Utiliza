using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeesDataAccess;

namespace Utiliza.ApplicationCore.Models
{
    public class UtilizaApplicationCoreContext : DbContext
    {
        public UtilizaApplicationCoreContext (DbContextOptions<UtilizaApplicationCoreContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeesDataAccess.Employee> Employee { get; set; }
    }
}
