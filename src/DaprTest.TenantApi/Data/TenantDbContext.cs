using DaprTest.Domain;
using DaprTest.Domain.Entities.Tenants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.TenantApi.Data
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options): base(options)
        {
        }

        public DbSet<TenantStaff> TenantStaffs { get; set; }
        public DbSet<StoreInfo> StoreInfos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //add-migration init -Context TenantDbContext -OutputDir Data/migrations
            //optionsBuilder.LogTo(Console.WriteLine);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
