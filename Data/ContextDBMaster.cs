using Microsoft.EntityFrameworkCore;
using Models.Master;
using Models.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ContextDBMaster : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AppMultiTenantDBMaster;Integrated Security=true");
        //    base.OnConfiguring(optionsBuilder);
        //    //Primer Migracion   Add-Migration InitialCreate -Context ContextDBMaster
        //    //Despues de la primera migracion se utiliza  Update-Database -Context ContextDBMaster

        //}
        public ContextDBMaster(DbContextOptions<ContextDBMaster> opt) : base(opt)
        {

        }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
