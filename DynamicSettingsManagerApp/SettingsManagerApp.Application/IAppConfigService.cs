﻿using SettingManagerApp.Domain.Entities;
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
        bool DeleteAppConfig(AppConfiguration appConfiguration);
        bool UpdateAppConfig(AppConfiguration appConfiguration);
        IEnumerable<AppConfiguration> GetAppConfigs();
        Task<AppConfiguration> GetAppConfigByIdAsync(int id);
        Task<AppConfiguration> GetAppConfigByNameAsync(string name);
    }
}
