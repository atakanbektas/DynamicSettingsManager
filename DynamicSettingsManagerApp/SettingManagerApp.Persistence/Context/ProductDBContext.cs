using Microsoft.EntityFrameworkCore;
using SettingManagerApp.Domain.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagerApp.Persistence.Context
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext()
        {

        }

        public ProductDBContext(DbContextOptions opt) : base(opt)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer(Settings.ConnStringServiceProduct);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
