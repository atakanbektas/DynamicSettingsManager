using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SettingManagerApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagerApp.Persistence.DbContextFactories
{
    public class ProductDBContextFactory : IDesignTimeDbContextFactory<ProductDBContext>
    {
        public ProductDBContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ProductDBContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(Settings.ConnStringServiceProduct);
            return new(optionsBuilder.Options);
        }
    }
}
