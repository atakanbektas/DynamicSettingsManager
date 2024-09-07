using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using SettingManagerApp.Domain.Entities;
using SettingsManagerApp.Application;

namespace SettingManagerApp.MVCUI.Controllers
{
    public class ConfigController : Controller
    {
        IAppConfigService _appConfigService;

        public ConfigController(IAppConfigService appConfigService)
        {
            _appConfigService = appConfigService;
        }

        //Tüm Configlerin Listelendiği Action
        public IActionResult Index()
        {
            var configs = _appConfigService.GetAppConfigs();
            return View(configs);
        }

        public async Task<IActionResult> ToggleActiveProp(int id)
        {
            var config = await _appConfigService.GetAppConfigByIdAsync(id);
            config.IsActive = !config.IsActive;
            _appConfigService.UpdateAppConfig(config);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateConfigAsync(AppConfiguration model)
        {
            if (ModelState.IsValid)
            {
                var isAdded = await _appConfigService.AddAppConfigAsync(model);
                if (isAdded)
                {
                    return RedirectToAction("Index");
                }
            }

            // Model geçerli değilse formu tekrar göster
            return View(model);
        }

    }
}
