using Microsoft.EntityFrameworkCore;
using SettingManagerApp.Persistence.Context;
using SettingsManagerApp.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagerApp.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SettingManagerDBContext _context;

        public Repository(SettingManagerDBContext context)
        {
            _context = context;
        }

        public DbSet<T> Tablo => _context.Set<T>();
    }
}
