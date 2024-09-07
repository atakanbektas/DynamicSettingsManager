using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SettingManagerApp.Persistence.Context;
using SettingsManagerApp.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagerApp.Persistence.Repositories
{
    public class WriteRepository<T> : Repository<T>, IWriteRepository<T> where T : class
    {
        public WriteRepository(SettingManagerDBContext context) : base(context) { }
        public WriteRepository(ProductDBContext context) : base(context) { }

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entry = await Tablo.AddAsync(entity);
            var result = entry.State == EntityState.Added;
            await SaveAsync();
            return result;
        }

        public bool Delete(T entity)
        {
            EntityEntry<T> entityEntry = Tablo.Remove(entity);
            bool result = entityEntry.State == EntityState.Deleted;
            Save();
            return result;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public bool Update(T entity)
        {
            EntityEntry<T> entityEntry = Tablo.Update(entity);
            bool result = entityEntry.State == EntityState.Modified;
            Save();
            return result;
        }
    }
}
