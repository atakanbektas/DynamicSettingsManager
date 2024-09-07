﻿using SettingManagerApp.Domain.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsManagerApp.Application.Repositories.ProductRepo
{
    public interface IProductWriteRepository : IWriteRepository<Product>
    {
        bool DeleteAll(IEnumerable<Product> products);
    }
}
