using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using SettingManagerApp.Domain.Entities;
using SettingsManagerApp.Application.Services;

namespace SettingManagerApp.MVCUI.Controllers
{
    public class ConfigController : Controller
    {
        private readonly IAppConfigService _appConfigService;

        public ConfigController(IAppConfigService appConfigService)
        {
            _appConfigService = appConfigService;
        }

        //Tüm Configlerin Listelendiği Action
        public async Task<IActionResult> Index()
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
            if (ModelState.IsValid && await _appConfigService.AddAppConfigAsync(model))
            {
                return RedirectToAction("Index");
            }

            // Model geçerli değilse veya ekleme sırasında hata olursa formu tekrar göster.
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var config = await _appConfigService.GetAppConfigByIdAsync(id);

            if (config == null)
            {
                return NotFound();
            }

            return View(config);
        }


        [HttpPost]
        public IActionResult EditConfig(AppConfiguration model)
        {
            if (ModelState.IsValid && _appConfigService.UpdateAppConfig(model))
            {
                return RedirectToAction("Index");
            }

            // Güncelleme başarısız olursa formu tekrar göster
            return View(model);
        }


    }
}
