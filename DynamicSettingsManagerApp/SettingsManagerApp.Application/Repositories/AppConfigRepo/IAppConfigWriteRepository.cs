using SettingManagerApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsManagerApp.Application.Repositories.AppConfigRepo
{
    public interface IAppConfigWriteRepository:IReadRepository<AppConfiguration>
    {

    }
}
