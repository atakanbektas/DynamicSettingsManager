using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SettingManagerApp.Domain.Entities;
using SettingManagerApp.Persistence.Hubs;
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
        private readonly IHubContext<ConfigHub> _hubContext;
        private readonly IMemoryCache _cache;

        public AppConfigService(IUnitOfWork unitOfWork, IHubContext<ConfigHub> hubContext, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _hubContext = hubContext;
            _cache = cache;
        }

        public async Task<bool> AddAppConfigAsync(AppConfiguration appConfiguration)
        {
            //return await _unitOfWork.AppConfigWrite.AddAsync(appConfiguration);

            var result = await _unitOfWork.AppConfigWrite.AddAsync(appConfiguration);

            if (result)
            {
                // Ekleme başarılı ise SignalR ile istemcilere bildirim gönder
               await _hubContext.Clients.All.SendAsync("UpdateConfig", appConfiguration.ApplicationName);

            }

            return result;
        }

        public bool DeleteAppConfig(AppConfiguration appConfiguration)
        {
            //return _unitOfWork.AppConfigWrite.Delete(appConfiguration);
            var result = _unitOfWork.AppConfigWrite.Delete(appConfiguration);

            if (result)
            {
                // Silme işlemi başarılı ise SignalR ile bildirim gönder
                _hubContext.Clients.All.SendAsync("UpdateConfig", appConfiguration.ApplicationName);
            }

            return result;
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
            //return _unitOfWork.AppConfigWrite.Update(appConfiguration);
            var result = _unitOfWork.AppConfigWrite.Update(appConfiguration);

            if (result)
            {
                // Güncelleme başarılı ise SignalR ile bildirim gönder
                _hubContext.Clients.All.SendAsync("UpdateConfig", appConfiguration.ApplicationName);
            }

            return result;
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


        private readonly TimeSpan cacheDuration = TimeSpan.FromDays(1);

        public async Task<IEnumerable<AppConfiguration>> GetAppConfigsByApplicationNameAsync(string name)
        {
            var cacheKey = $"Config_{name}";
            try
            {
                // Veritabanından veri çekmeye çalış
                var configs = await _unitOfWork.AppConfigRead.GetAll()
                    .Where(config => config.IsActive == true)
                    .Where(config => config.ApplicationName == name)
                    .ToListAsync();

                //Cache test ederken kullanılabilir.
                //int x = 0;
                //x = x / x;

                // Eğer veri geldiyse cache'e kaydet
                _cache.Set(cacheKey, configs, cacheDuration);

                return configs;
            }
            catch (Exception)
            {
                // Eğer veritabanına erişim başarısız olursa, cache'deki veriyi kullan
                if (_cache.TryGetValue(cacheKey, out IEnumerable<AppConfiguration> fallbackConfigs))
                {
                    return fallbackConfigs;  // Cache'deki veriyi geri dön
                }

                // Eğer cache'de de veri yoksa boş bir liste dön veya hata fırlat (tercihe bağlı)
                return Enumerable.Empty<AppConfiguration>();  // Boş liste döndür
            }
        }

    }
}
