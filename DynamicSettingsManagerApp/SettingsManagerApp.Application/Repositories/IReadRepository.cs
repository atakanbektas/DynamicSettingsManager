﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsManagerApp.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByKeysAsync(params object?[]? keyValues);

    }
}
