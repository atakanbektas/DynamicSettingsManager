using Microsoft.AspNetCore.Mvc;
using SettingManagerApp.Domain.Entities.ProductEntities;
using SettingManagerApp.MVCUI.Models;
using SettingManagerApp.Persistence.Context;
using SettingsManagerApp.Application.Services;

namespace SettingManagerApp.MVCUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService, IAppConfigService appConfigService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = _productService.GetProducts().ToList();
            var configs = await _productService.GetConfigurationsAsync();

            ProductConfigVM vm = new()
            {
                Products = products,
                Configurations = configs
            };

            return View(vm);
        }

        public async Task<IActionResult> CreateAsync()
        {
            int? maxProductCount = await _productService.GetConfigValue<int>("MaxProductCount");
            if (maxProductCount != null) // ayar var, kontrollü ekle
            {
                int currentProductCount = _productService.GetProducts().Count();
                if (currentProductCount < maxProductCount)
                {
                    await _productService.AddProductAsync(new Product());
                }
                else
                {
                    TempData["AlertMessage"] = "En Fazla " + maxProductCount + " Urun Olusturabilirsiniz";
                }
                return RedirectToAction("Index");
            }
            else // ayar yok, kontrolsüz ekle
            {
                await _productService.AddProductAsync(new Product());
                return RedirectToAction("Index");
            }


        }





        public IActionResult DeleteAll()
        {
            bool isDeleted = _productService.DeleteAllProduct();
            return RedirectToAction("Index");
        }
    }
}
