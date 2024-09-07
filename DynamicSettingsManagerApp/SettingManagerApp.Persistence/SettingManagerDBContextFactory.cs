using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SettingManagerApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagerApp.Persistence
{
    public class SettingManagerDBContextFactory : IDesignTimeDbContextFactory<SettingManagerDBContext>
    {
        public SettingManagerDBContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<SettingManagerDBContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(Settings.ConnString);
            return new(optionsBuilder.Options);
        }
    }
}
