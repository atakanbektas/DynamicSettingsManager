using Microsoft.AspNetCore.Mvc;
using SettingManagerApp.Domain.Entities.ProductEntities;
using SettingManagerApp.Persistence.Context;
using SettingsManagerApp.Application.Services;

namespace SettingManagerApp.MVCUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetProducts().ToList();
            return View(products);
        }

        public async Task<IActionResult> CreateAsync() 
        {
            await _productService.AddProductAsync(new Product());
            return RedirectToAction("Index");
        }


        public IActionResult DeleteAll()
        {
            bool isDeleted = _productService.DeleteAllProduct();
            return RedirectToAction("Index");
        }
    }
}
