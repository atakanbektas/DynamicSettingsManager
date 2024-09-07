using SettingManagerApp.Domain.Entities;
using SettingManagerApp.Domain.Entities.ProductEntities;
using SettingsManagerApp.Application;
using SettingsManagerApp.Application.Repositories.ProductRepo;
using SettingsManagerApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagerApp.Persistence.Concretes
{

    public class ProductService : IProductService
    {
        private readonly IProductReadRepository _productRead;
        private readonly IProductWriteRepository _productWrite;

        private readonly IAppConfigService _appConfigService;

        public ProductService(IProductWriteRepository productWrite, IProductReadRepository productRead, IAppConfigService appConfigService)
        {
            _productWrite = productWrite;
            _productRead = productRead;
            _appConfigService = appConfigService;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            return await _productWrite.AddAsync(product);
        }

        public bool DeleteAllProduct()
        {
            var allProducts = _productRead.GetAll();
            return _productWrite.DeleteAll(allProducts);
        }


        public Task<IEnumerable<AppConfiguration>> GetConfigurationsAsync()
        {
            return _appConfigService.GetAppConfigsByApplicationNameAsync("SERVICE-PRODUCT");
        }

        public async Task<T?> GetConfigValue<T>(string key) where T : struct
        {
            return await _appConfigService.GetValueAsync<T>(key);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRead.GetAll();
        }
    }

}
