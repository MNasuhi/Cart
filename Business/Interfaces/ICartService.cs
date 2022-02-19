using Common.ResultModels;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICartService
    {
        Task<IDataResult<GetCartResponseModel>> GetCartByUserId(int userId);

        Task<IDataResult<GetCartResponseModel>> GetCartByCartId(int cartId);

        Task<IResult> AddProductToCart(AddProductToCartRequestModel requestModel);
        Task<IResult> RemoveProductFromCart(RemoveProductFromCartRequestModel requestModel);
        Task<IResult> ClearCart(ClearCartRequestModel requestModel);
        Task<IResult> RemoveThisProductFromCart(RemoveThisProductFromCart requestModel);
    }
}
