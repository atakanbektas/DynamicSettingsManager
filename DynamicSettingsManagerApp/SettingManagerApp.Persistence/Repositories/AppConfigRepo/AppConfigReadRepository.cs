using SettingManagerApp.Domain.Entities;
using SettingManagerApp.Persistence.Context;
using SettingsManagerApp.Application.Repositories.AppConfigRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagerApp.Persistence.Repositories.AppConfigRepo
{
    public class AppConfigReadRepository : ReadRepository<AppConfiguration>, IAppConfigReadRepository
    {
        public AppConfigReadRepository(SettingManagerDBContext context) : base(context)
        {
        }
    }
}
