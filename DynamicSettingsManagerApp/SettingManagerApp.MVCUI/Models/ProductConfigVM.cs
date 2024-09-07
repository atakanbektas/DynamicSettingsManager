using Microsoft.Identity.Client;
using SettingManagerApp.Domain.Entities;
using SettingManagerApp.Domain.Entities.ProductEntities;

namespace SettingManagerApp.MVCUI.Models
{
    public class ProductConfigVM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<AppConfiguration> Configurations { get; set; }
    }
}
