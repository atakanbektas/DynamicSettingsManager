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
        public ProductWriteRepository(ProductDBContext context) : base(context)
        {
        }

        public bool DeleteAll(IEnumerable<Product> products)
        {
            if (products == null)
            {
                return false;
            }
            foreach (var item in products)
            {
                if (item != null)
                {
                    Tablo.Remove(item);
                    _context.SaveChanges();
                }
            }
            return true;
        }
    }
}
