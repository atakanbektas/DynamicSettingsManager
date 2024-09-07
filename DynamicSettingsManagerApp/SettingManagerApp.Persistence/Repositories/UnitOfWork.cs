using Microsoft.EntityFrameworkCore;
using SettingManagerApp.Persistence.Context;
using SettingsManagerApp.Application;
using SettingsManagerApp.Application.Repositories.AppConfigRepo;
using SettingsManagerApp.Application.Repositories.ProductRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagerApp.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SettingManagerDBContext _dbContext;

        public IAppConfigWriteRepository AppConfigWrite { get; }
        public IAppConfigReadRepository AppConfigRead { get; }

        public IProductReadRepository ProductRead { get; }
        public IProductWriteRepository ProductWrite { get; }

        public UnitOfWork(SettingManagerDBContext dbContext, IAppConfigWriteRepository configWrite, IAppConfigReadRepository configRead, IProductReadRepository productRead, IProductWriteRepository productWrite)
        {
            _dbContext = dbContext;
            AppConfigWrite = configWrite;
            AppConfigRead = configRead;
            ProductRead = productRead;
            ProductWrite = productWrite;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
