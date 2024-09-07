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
    }
}
