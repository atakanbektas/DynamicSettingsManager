using SettingManagerApp.Domain.Entities.ProductEntities;
using SettingManagerApp.Persistence.Context;
using SettingsManagerApp.Application.Repositories;
using SettingsManagerApp.Application.Repositories.ProductRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagerApp.Persistence.Repositories.ProductRepo
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(SettingManagerDBContext context) : base(context)
        {
        }

        public bool DeleteAll(IEnumerable<Product> products)
        {
            if (products != null)
            {
                Tablo.RemoveRange(products);
                return true;
            }
            return false;
        }
    }
}
