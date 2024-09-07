using Microsoft.EntityFrameworkCore;
using SettingManagerApp.Domain.Entities;
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

        public SettingManagerDBContext(DbContextOptions opt) : base(opt)
        {

        }

        public DbSet<AppConfiguration> AppConfigurations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(Settings.ConnString);

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
                    ApplicationName = "SERVICE-A",
                },

                new AppConfiguration()
                {
                    Id = 2,
                    Name = "IsBasketEnabled",
                    Type = "bool",
                    Value = "1",
                    IsActive = true,
                    ApplicationName = "SERVICE-B",
                },

                new AppConfiguration()
                {
                    Id = 3,
                    Name = "MaxItemCount",
                    Type = "int",
                    Value = "50",
                    IsActive = false,
                    ApplicationName = "SERVICE-A",
                });
        }
    }
}
