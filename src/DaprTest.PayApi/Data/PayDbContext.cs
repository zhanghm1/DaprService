using DaprTest.Domain;
using DaprTest.Domain.Entities.Orders;
using DaprTest.Domain.Entities.Pays;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.PayApi.Data
{
    public class PayDbContext : DbContext
    {
        public PayDbContext(DbContextOptions<PayDbContext> options): base(options)
        {
        }

        public DbSet<PaymentRecord> PaymentRecords { get; set; }
        public DbSet<PaymentChannel> PaymentChannels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //add-migration init -Context PayDbContext -OutputDir Data/migrations
            //optionsBuilder.LogTo(Console.WriteLine);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
