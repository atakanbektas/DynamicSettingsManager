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
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        //protected readonly SettingManagerDBContext _context;
        //protected readonly ProductDBContext _contextProduct;

        //public Repository(SettingManagerDBContext context)
        //{
        //    _context = context;
        //}

        //public Repository(ProductDBContext contextProduct)
        //{
        //    _contextProduct = contextProduct;
        //}

        public DbSet<T> Tablo => _context.Set<T>();
    }
}
