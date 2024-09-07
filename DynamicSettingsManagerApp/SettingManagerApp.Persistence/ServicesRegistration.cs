using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SettingManagerApp.Persistence.Concretes;
using SettingManagerApp.Persistence.Context;
using SettingManagerApp.Persistence.Repositories;
using SettingManagerApp.Persistence.Repositories.AppConfigRepo;
using SettingsManagerApp.Application;
using SettingsManagerApp.Application.Repositories.AppConfigRepo;
using SettingsManagerApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagerApp.Persistence
{
    public static class ServicesRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IAppConfigService, AppConfigService>();
            services.AddScoped<IAppConfigReadRepository, AppConfigReadRepository>();
            services.AddScoped<IAppConfigWriteRepository, AppConfigWriteRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddDbContext<SettingManagerDBContext>(opt=>opt.UseSqlServer(Settings.ConnString));
            services.AddDbContext<ProductDBContext>(opt=>opt.UseSqlServer(Settings.ConnStringServiceProduct));
        }
    }
}
