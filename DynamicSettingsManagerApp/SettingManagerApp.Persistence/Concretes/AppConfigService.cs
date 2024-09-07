using Microsoft.EntityFrameworkCore;
using SettingManagerApp.Domain.Entities;
using SettingsManagerApp.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagerApp.Persistence.Concretes
{
    public class AppConfigService : IAppConfigService
    {

        private readonly IUnitOfWork _unitOfWork;
        public AppConfigService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAppConfigAsync(AppConfiguration appConfiguration)
        {
            return await _unitOfWork.AppConfigWrite.AddAsync(appConfiguration);
        }

        public bool DeleteAppConfig(AppConfiguration appConfiguration)
        {
            return _unitOfWork.AppConfigWrite.Delete(appConfiguration);
        }

        public async Task<AppConfiguration> GetAppConfigByNameAsync(string name)
        {
            return await _unitOfWork.AppConfigRead.GetByKeysAsync(name);
        }

        public async Task<AppConfiguration> GetAppConfigByIdAsync(int id)
        {
            return await _unitOfWork.AppConfigRead.GetByKeysAsync(id);
        }

        public IEnumerable<AppConfiguration> GetAppConfigs()
        {
            return _unitOfWork.AppConfigRead.GetAll();
        }

        public bool UpdateAppConfig(AppConfiguration appConfiguration)
        {
            return _unitOfWork.AppConfigWrite.Update(appConfiguration);
        }
    }
}
