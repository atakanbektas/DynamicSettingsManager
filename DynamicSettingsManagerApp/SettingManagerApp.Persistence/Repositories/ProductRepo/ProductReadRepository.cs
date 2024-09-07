using SettingManagerApp.Domain.Entities.ProductEntities;
using SettingManagerApp.Persistence.Context;
using SettingsManagerApp.Application.Repositories.ProductRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagerApp.Persistence.Repositories.ProductRepo
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(ProductDBContext context) : base(context)
        {

        }
    }
}
