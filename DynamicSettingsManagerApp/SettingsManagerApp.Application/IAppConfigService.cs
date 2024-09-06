using SettingManagerApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsManagerApp.Application
{
    public interface IAppConfigService
    {
        Task<bool> AddAppConfigAsync(AppConfiguration appConfiguration);
        Task<bool> GetAppConfigAsync(AppConfiguration appConfiguration);
        Task<bool> DeleteAppConfigAsync(AppConfiguration appConfiguration);
        Task<bool> UpdateAppConfigAsync(int id, AppConfiguration appConfiguration);
        Task<AppConfiguration> GetAppConfigByNameAsync(string name);
        Task<IEnumerable<AppConfiguration>> GetAppConfigsAsync();
    }
}
