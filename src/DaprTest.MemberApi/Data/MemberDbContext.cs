using DaprTest.Domain;
using DaprTest.Domain.Entities.Members;
using DaprTest.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.MemberApi.Data
{
    public class MemberDbContext : DbContext
    {
        public MemberDbContext(DbContextOptions<MemberDbContext> options): base(options)
        {
        }

        public DbSet<Member> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //add-migration init -Context MemberDbContext -OutputDir Data/migrations
            //optionsBuilder.LogTo(Console.WriteLine);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
