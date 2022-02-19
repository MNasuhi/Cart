using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        ICartService cs;
        public CartController(ICartService _cs)
        {
            cs = _cs;
        }

        [HttpGet("getCartByUserId/{UserId}")]
        public async Task<ActionResult> GetCartByUserId(int UserId)
        {
            var response = await cs.GetCartByUserId(UserId);
            if(response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("getCartByCartId/{CartId}")]
        public async Task<ActionResult> GetCartByCartId(int CartId)
        {
            var response = await cs.GetCartByCartId(CartId);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("addProductToCart")]
        public async Task<ActionResult> AddProductToCart([FromBody] AddProductToCartRequestModel requestModel)
        {

            var response = await cs.AddProductToCart(requestModel);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("removeProductFromCart")]
        public async Task<ActionResult> RemoveProductFromCart([FromBody] RemoveProductFromCartRequestModel requestModel)
        {

            var response = await cs.RemoveProductFromCart(requestModel);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("removeThisProductFromCart")]
        public async Task<ActionResult> RemoveThisProductFromCart([FromBody] RemoveThisProductFromCart requestModel)
        {

            var response = await cs.RemoveThisProductFromCart(requestModel);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("clearCart")]
        public async Task<ActionResult> ClearCart([FromBody] ClearCartRequestModel requestModel)
        {

            var response = await cs.ClearCart(requestModel);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

    }
}
