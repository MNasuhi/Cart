using Business.Interfaces;
using Common.ResultModels;
using Data.Models;
using DataAccess.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork uow;
        public ProductService(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        public async Task<IDataResult<List<ProductResponseModel>>> GetAllProducts()
        {
            var dataList = new List<ProductResponseModel>();
            var data = await uow.ProductRepository.GetList();
            foreach (var item in data)
            {
                var prodModel = new ProductResponseModel()
                {
                    Id = item.Id,
                    ProductCode = item.ProductCode,
                    ProductName = item.ProductName,
                    Amount = item.Amount,
                    Quantity = item.Quantity
                };
                dataList.Add(prodModel);
            }
            return new SuccessDataResult<List<ProductResponseModel>>("İşlem Başarılı.",dataList);
        }

        public async Task<IDataResult<ProductResponseModel>> GetProductByProductCode(string productCode)
        {
            var response = await uow.ProductRepository.Get(x => x.ProductCode == productCode);
            if(response == null)
            {
                return new ErrorDataResult<ProductResponseModel>($"{productCode} kodlu ürün bulunamadı.", null);
            }
            var prodModel = new ProductResponseModel()
            {
                Id = response.Id,
                ProductCode = response.ProductCode,
                ProductName = response.ProductName,
                Amount = response.Amount,
                Quantity = response.Quantity
            };
            return new SuccessDataResult<ProductResponseModel>("İşlem başarılı.", prodModel);
        }

        public async Task<IDataResult<ProductResponseModel>> GetProductByProductId(int productId)
        {
            var response = await uow.ProductRepository.Get(x => x.Id == productId);
            if (response == null)
            {
                return new ErrorDataResult<ProductResponseModel>($"Böyle bir ürün bulunamadı.", null);
            }
            var prodModel = new ProductResponseModel()
            {
                Id = response.Id,
                ProductCode = response.ProductCode,
                ProductName = response.ProductName,
                Amount = response.Amount,
                Quantity = response.Quantity
            };
            return new SuccessDataResult<ProductResponseModel>("İşlem başarılı.", prodModel);
        }
    }
}
