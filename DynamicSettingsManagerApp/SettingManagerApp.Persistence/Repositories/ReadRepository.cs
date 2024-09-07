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
    public class ReadRepository<T> : Repository<T>, IReadRepository<T> where T : class
    {
        public ReadRepository(SettingManagerDBContext context) : base(context) { }
        public ReadRepository(ProductDBContext context) : base(context) { }

        public IQueryable<T> GetAll()
        {
            return Tablo;
        }

        public async Task<T> GetByKeysAsync(params object?[]? keyValues)
        {
            return await Tablo.FindAsync(keyValues);
        }
    }
}
