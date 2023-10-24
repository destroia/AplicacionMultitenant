using Microsoft.EntityFrameworkCore;
using Models.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ContextDBTenant : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AppMultiTenantDBTenant;Integrated Security=true");
        //    base.OnConfiguring(optionsBuilder);
        //    //Primer Migracion   Add-Migration InitialCreate
        //    //Despues de la primera migracion se utiliza  Update-Database

        //}
        public ContextDBTenant(DbContextOptions<ContextDBTenant> opt) : base(opt)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
