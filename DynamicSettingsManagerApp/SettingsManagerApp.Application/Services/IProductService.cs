using SettingManagerApp.Domain.Entities;
using SettingManagerApp.Domain.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsManagerApp.Application.Services
{
    public interface IProductService
    {
        Task<bool> AddProductAsync(Product product);
        IEnumerable<Product> GetProducts();
        bool DeleteAllProduct();

        Task<T?> GetConfigValue<T>(string key) where T : struct;
        Task<IEnumerable<AppConfiguration>> GetConfigurationsAsync();
    }
}
