using Common.ResultModels;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProductService
    {
        Task<IDataResult<List<ProductResponseModel>>> GetAllProducts();
        Task<IDataResult<ProductResponseModel>> GetProductByProductId(int productId);
        Task<IDataResult<ProductResponseModel>> GetProductByProductCode(string productCode);
    }
}
