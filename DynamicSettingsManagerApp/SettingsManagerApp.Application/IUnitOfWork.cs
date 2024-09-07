using SettingsManagerApp.Application.Repositories.AppConfigRepo;
using SettingsManagerApp.Application.Repositories.ProductRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsManagerApp.Application
{
    public interface IUnitOfWork : IDisposable
    {
        //APPCONFIG
        IAppConfigReadRepository AppConfigRead { get; }
        IAppConfigWriteRepository AppConfigWrite { get; }

        //PRODUCT
        //IProductReadRepository ProductRead { get; }
        //IProductWriteRepository ProductWrite { get; }
    }
}
