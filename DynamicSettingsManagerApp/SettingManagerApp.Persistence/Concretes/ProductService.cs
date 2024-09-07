using SettingManagerApp.Domain.Entities;
using SettingManagerApp.Domain.Entities.ProductEntities;
using SettingsManagerApp.Application;
using SettingsManagerApp.Application.Repositories.ProductRepo;
using SettingsManagerApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagerApp.Persistence.Concretes
{

    public class ProductService : IProductService
    {
        private readonly IProductReadRepository _productRead;
        private readonly IProductWriteRepository _productWrite;

        public ProductService(IProductWriteRepository productWrite, IProductReadRepository productRead)
        {
            _productWrite = productWrite;
            _productRead = productRead;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            return await _productWrite.AddAsync(product);
        }

        public bool DeleteAllProduct()
        {
            var allProducts = _productRead.GetAll();
            return _productWrite.DeleteAll(allProducts);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRead.GetAll();
        }
    }


    //public class ProductService : IProductService
    //{
    //    private readonly IUnitOfWork _unitOfWork;
    //    public ProductService(IUnitOfWork unitOfWork)
    //    {
    //        _unitOfWork = unitOfWork;
    //    }

    //    public async Task<bool> AddProductAsync(Product product)
    //    {
    //        return await _unitOfWork.ProductWrite.AddAsync(product);
    //    }

    //    public bool DeleteAllProduct()
    //    {
    //        var allProducts = _unitOfWork.ProductRead.GetAll();
    //        return _unitOfWork.ProductWrite.DeleteAll(allProducts);
    //    }

    //    public IEnumerable<Product> GetProducts()
    //    {
    //        return _unitOfWork.ProductRead.GetAll();
    //    }
    //}
}
