using SettingsManagerApp.Application.Repositories.AppConfigRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsManagerApp.Application
{
    public interface IUnitOfWork : IDisposable
    {
        IAppConfigReadRepository AppConfigRead { get; }
        IAppConfigWriteRepository AppConfigWrite { get; }
    }
}
