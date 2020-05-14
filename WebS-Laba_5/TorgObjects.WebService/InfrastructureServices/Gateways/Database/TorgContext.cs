using Microsoft.EntityFrameworkCore;
using TorgObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace TorgObjects.InfrastructureServices.Gateways.Database
{
    public class TorgContext : DbContext
    {
        public DbSet<TorgPoint> TorgPoints { get; set; }

        public TorgContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillTestData(modelBuilder);
        }
        private void FillTestData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TorgPoint>().HasData(
                new
                {
                    Id = 1L,
                    IsPechatProducts = "9",
                    FullName = @"НТО Гримау ул., вл. 14",
                
                },
                new
                {
                    Id = 2L,
                    IsPechatProducts = "6",
                    FullName = @"НТО Губкина ул., вл.14",

                },
                new
                {
                    Id = 3L,
                    IsPechatProducts = "6",
                    FullName = @"НТО Нахимовский проспект, вл. 42",

                },
                new
                {
                    Id = 4L,
                    IsPechatProducts = "12",
                    FullName = @"НТО Кржижановского ул., вл. 17-19",
 
                }
            );
        }
    }
}
