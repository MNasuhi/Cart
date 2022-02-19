using Business.Interfaces;
using Common.ResultModels;
using Data.Entities;
using Data.Models;
using DataAccess.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CartService : ICartService
    {
        private IUnitOfWork uow;

        public CartService(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        public async Task<IResult> AddProductToCart(AddProductToCartRequestModel requestModel)
        {
            var productControl = await uow.ProductRepository.Get(x => x.Id == requestModel.ProductId);
            if (productControl == null)
            {
                return new ErrorResult($"Ürün bulunamadı.");
            }
            if (productControl.Quantity < 1 || requestModel.ProductCount > productControl.Quantity)
            {
                return new ErrorResult($"{productControl.ProductCode} isimli üründen {productControl.Quantity} adet kaldığı için ekleme yapılamıyor.");
            }

            var userCart = await uow.CartRepository.Get(x => x.UserId == requestModel.UserId && x.Id == requestModel.CartId);
            if (userCart == null)
            {
                return new ErrorResult($"Sepet bulunamadı.");
            }
            userCart.TotalAmount = userCart.TotalAmount + (requestModel.ProductCount * productControl.Amount);
            userCart.TotalProductCount = requestModel.ProductCount + userCart.TotalProductCount;
            await uow.CartRepository.Update(userCart);

            productControl.Quantity = productControl.Quantity - requestModel.ProductCount;
            await uow.ProductRepository.Update(productControl);

            var productChart = new ProductsInCart();
            var hasProduct = await uow.ProductsInCartRepository.Get(x => x.ProductId == requestModel.ProductId && x.CartId == requestModel.CartId && x.Status != Data.Enums.Status.Deleted);
            if(hasProduct == null)
            {
                productChart.CartId = userCart.Id;
                productChart.ProductId = requestModel.ProductId;
                productChart.ProductCount = requestModel.ProductCount;
                await uow.ProductsInCartRepository.Add(productChart);
            }
            else
            {
                hasProduct.ProductCount = requestModel.ProductCount + hasProduct.ProductCount;
                await uow.ProductsInCartRepository.Update(hasProduct);
            }
            uow.SaveChanges();
            return new SuccessResult($"{productControl.ProductCode} adlı üründen {requestModel.ProductCount} adet sepete eklendi.");
        }


        public async Task<IDataResult<GetCartResponseModel>> GetCartByCartId(int cartId)
        {
            var productsInCart = await uow.ProductsInCartRepository.GetList(x => x.CartId == cartId && x.Status != Data.Enums.Status.Deleted);
            var cart = await uow.CartRepository.Get(x => x.Id == cartId);
            if (cart == null)
            {
                return new ErrorDataResult<GetCartResponseModel>($"Sepet bulunamadı.",null);
            }
            var data = new GetCartResponseModel()
            {
                CartId = cart.Id,
                TotalAmount = cart.TotalAmount,
                TotalCount = cart.TotalProductCount,
                UserId = cart.UserId
            };

            var products = new List<Product>();
            foreach (var item in productsInCart)
            {
                var prod = await uow.ProductRepository.Get(x => x.Id == item.ProductId);
                prod.Quantity = item.ProductCount;
                products.Add(prod);
            }
            data.Products = products;


            var response = new SuccessDataResult<GetCartResponseModel>("İşlem Başarılı.",data);
            return response;

        }

        public async Task<IDataResult<GetCartResponseModel>> GetCartByUserId(int userId)
        {
            try
            {
                var cart = await uow.CartRepository.Get(x => x.UserId == userId);
                if (cart == null)
                {
                    return new ErrorDataResult<GetCartResponseModel>($"Sepet bulunamadı.", null);
                }
                var productsInCart = await uow.ProductsInCartRepository.GetList(x => x.CartId == cart.Id && x.Status != Data.Enums.Status.Deleted);
                var data = new GetCartResponseModel()
                {
                    CartId = cart.Id,
                    TotalAmount = cart.TotalAmount,
                    TotalCount = cart.TotalProductCount,
                    UserId = cart.UserId
                };
                var products = new List<Product>();
                foreach (var item in productsInCart)
                {
                    var prod = await uow.ProductRepository.Get(x => x.Id == item.ProductId);
                    prod.Quantity = item.ProductCount;
                    products.Add(prod);
                }
                data.Products = products;


                var response = new SuccessDataResult<GetCartResponseModel>("İşlem Başarılı", data);
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<IResult> RemoveProductFromCart(RemoveProductFromCartRequestModel requestModel)
        {
            var cart = await uow.CartRepository.Get(x => x.Id == requestModel.CartId && x.UserId == requestModel.UserId);
            if (cart == null)
            {
                return new ErrorResult($"Sepet bulunamadı.");
            }
            var product = await uow.ProductRepository.Get(x => x.Id == requestModel.ProductId);
            if (product == null)
            {
                return new ErrorResult($"Ürün bulunamadı.");
            }
            var productsInCart = await uow.ProductsInCartRepository.Get(x => x.ProductId == requestModel.ProductId && x.CartId == cart.Id && x.Status != Data.Enums.Status.Deleted);
            if (productsInCart == null)
            {
                return new ErrorResult($"Ürün bulunamadı.");
            }
            if(productsInCart.ProductCount < requestModel.ProductCount)
            {
                return new ErrorResult($"Sepetinizde {product.ProductCode} ürününden {productsInCart.ProductCount} adet olduğu için sepetten çıkarma başarısız.");
            }
            cart.TotalAmount = cart.TotalAmount - (requestModel.ProductCount * product.Amount);
            cart.TotalProductCount = cart.TotalProductCount - requestModel.ProductCount;
            await uow.CartRepository.Update(cart);

            product.Quantity = product.Quantity + requestModel.ProductCount;
            await uow.ProductRepository.Update(product);

            productsInCart.ProductCount = productsInCart.ProductCount - requestModel.ProductCount;
            if(productsInCart.ProductCount <= 0)
            {
                productsInCart.Status = Data.Enums.Status.Deleted;
                await uow.ProductsInCartRepository.Update(productsInCart);
            }
            else
            {
                await uow.ProductsInCartRepository.Update(productsInCart);
            }

            uow.SaveChanges();

            return new SuccessResult($"{product.ProductCode} adlı ürün sepetten silindi.");


        }

        public async Task<IResult> ClearCart(ClearCartRequestModel requestModel)
        {
            var cart = await uow.CartRepository.Get(x => x.Id == requestModel.CartId && x.UserId == requestModel.UserId);
            if (cart == null)
            {
                return new ErrorResult($"Sepet bulunamadı.");
            }
            
            var prodsInCart = await uow.ProductsInCartRepository.GetList(x => x.CartId == cart.Id && x.Status != Data.Enums.Status.Deleted);

            cart.TotalAmount = 0;
            cart.TotalProductCount = 0;
            await uow.CartRepository.Update(cart);

            foreach (var item in prodsInCart)
            {
                await uow.ProductsInCartRepository.Delete(item);
                var prod = await uow.ProductRepository.Get(x => x.Id == item.ProductId);
                prod.Quantity = prod.Quantity + item.ProductCount;
                await uow.ProductRepository.Update(prod);

            }

            uow.SaveChanges();

            return new SuccessResult("Sepetteki tüm ürünler silindi.");

            
        }

        public async Task<IResult> RemoveThisProductFromCart(RemoveThisProductFromCart requestModel)
        {

            var cart = await uow.CartRepository.Get(x => x.Id == requestModel.CartId && x.UserId == requestModel.UserId);
            if (cart == null)
            {
                return new ErrorResult($"Sepet bulunamadı.");
            }
            var product = await uow.ProductRepository.Get(x => x.Id == requestModel.ProductId);
            if (product == null)
            {
                return new ErrorResult($"Ürün bulunamadı.");
            }
            var prodsInCart = await uow.ProductsInCartRepository.GetList(x => x.ProductId == requestModel.ProductId && x.CartId == cart.Id && x.Status != Data.Enums.Status.Deleted);


            foreach (var item in prodsInCart)
            {
                await uow.ProductsInCartRepository.Delete(item);
                var prod = await uow.ProductRepository.Get(x => x.Id == item.ProductId);
                prod.Quantity = prod.Quantity + item.ProductCount;
                await uow.ProductRepository.Update(prod);

                cart.TotalAmount = cart.TotalAmount - (product.Amount * item.ProductCount);
                cart.TotalProductCount = cart.TotalProductCount - item.ProductCount;
                await uow.CartRepository.Update(cart);

            }

            uow.SaveChanges();

            return new SuccessResult("Bu ürün sepetten silindi.");
        }
    }
}
