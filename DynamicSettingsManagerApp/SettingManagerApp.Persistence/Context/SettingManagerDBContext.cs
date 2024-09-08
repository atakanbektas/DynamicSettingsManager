using Microsoft.EntityFrameworkCore;
using SettingManagerApp.Domain.Entities;
using SettingManagerApp.Domain.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagerApp.Persistence.Context
{
    public class SettingManagerDBContext : DbContext
    {
        public SettingManagerDBContext()
        {

        }

        public SettingManagerDBContext(DbContextOptions<SettingManagerDBContext> opt) : base(opt)
        {

        }


        public DbSet<AppConfiguration> AppConfigurations { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseSqlServer(Settings.ConnString);

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)  // Eğer DI tarafından ayarlanmamışsa çalışır
        //    {
        //        optionsBuilder.UseSqlServer(Settings.ConnString);
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            AddDummyRoles(builder);
        }

        private static void AddDummyRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfiguration>().HasData(
                new AppConfiguration()
                {
                    Id = 1,
                    Name = "SiteName",
                    Type = "string",
                    Value = "soty.io",
                    IsActive = true,
                    ApplicationName = "SERVICE-PRODUCT",
                },

                new AppConfiguration()
                {
                    Id = 2,
                    Name = "IsBasketEnabled",
                    Type = "bool",
                    Value = "1",
                    IsActive = true,
                    ApplicationName = "SERVICE-PRODUCT",
                },

                new AppConfiguration()
                {
                    Id = 3,
                    Name = "MaxItemCount",
                    Type = "int",
                    Value = "50",
                    IsActive = true,
                    ApplicationName = "SERVICE-OTHER",
                },
                new AppConfiguration()
                {
                    Id = 4,
                    Name = "Template",
                    Type = "string",
                    Value = "dark",
                    IsActive = false,
                    ApplicationName = "SERVICE-PRODUCT",
                },
                new AppConfiguration()
                {
                    Id = 5,
                    Name = "MaxProductCount",
                    Type = "int",
                    Value = "5",
                    IsActive = true,
                    ApplicationName = "SERVICE-PRODUCT",
                });
        }
    }
}
