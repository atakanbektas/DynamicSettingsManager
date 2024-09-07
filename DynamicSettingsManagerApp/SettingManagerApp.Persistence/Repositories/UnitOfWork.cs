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
        private readonly SettingManagerDBContext _dbAppConfig;
        public IAppConfigWriteRepository AppConfigWrite { get; }
        public IAppConfigReadRepository AppConfigRead { get; }

        private readonly ProductDBContext _dbProduct;
        public IProductReadRepository ProductRead { get; }
        public IProductWriteRepository ProductWrite { get; }

        public UnitOfWork(SettingManagerDBContext dbAppConfig, IAppConfigWriteRepository configWrite, IAppConfigReadRepository configRead, ProductDBContext dbProduct , IProductReadRepository productRead, IProductWriteRepository productWrite)
        {
            _dbAppConfig = dbAppConfig;
            AppConfigWrite = configWrite;
            AppConfigRead = configRead;

            _dbProduct = dbProduct;
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
                _dbProduct.Dispose();
                _dbAppConfig.Dispose();
            }
        }
    }
}
