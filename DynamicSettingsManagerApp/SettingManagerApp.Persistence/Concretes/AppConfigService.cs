using Microsoft.EntityFrameworkCore;
using SettingManagerApp.Domain.Entities;
using SettingsManagerApp.Application;
using SettingsManagerApp.Application.Services;
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

        public async Task<T?> GetValueAsync<T>(string name) where T : struct
        {
            var config = await _unitOfWork.AppConfigRead.GetAll()!.FirstOrDefaultAsync(x => x.Name == name && x.IsActive == true);

            // Eğer bu isimde config yoksa veya pasifse, null döndür
            if (config == null)
            {
                return null;
            }

            // Veritabanındaki value değeri string olarak saklanıyor, bu değeri T tipine dönüştürüyoruz
            string valueAsString = config.Value;
            return (T)ConvertValueToType(typeof(T), valueAsString);
        }

        private object ConvertValueToType(Type targetType, string valueAsString)
        {
            if (targetType == typeof(int))
            {
                return int.Parse(valueAsString);
            }
            else if (targetType == typeof(bool))
            {
                return bool.Parse(valueAsString);
            }
            else if (targetType == typeof(double))
            {
                return double.Parse(valueAsString);
            }
            else if (targetType == typeof(string))
            {
                return valueAsString;  // String ise dönüşüme gerek yok
            }
            else
            {
                return $"Unsupported type: {targetType.Name}";
            }
        }

        public async Task<IEnumerable<AppConfiguration>> GetAppConfigsByApplicationNameAsync(string name)
        {
            var config = await _unitOfWork.AppConfigRead.GetAll()
                .Where(config => config.IsActive == true)
                .Where(config => config.ApplicationName == name).ToListAsync();

            return config;
        }

    }
}
