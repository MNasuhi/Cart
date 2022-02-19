using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService ps;

        public ProductController(IProductService _ps)
        {
            ps = _ps;
        }

        [HttpGet("getAllProducts")]
        public async Task<ActionResult> GetAllProducts()
        {
            var response = await ps.GetAllProducts();
            if(response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("getProductByProductId/{ProductId}")]
        public async Task<ActionResult> GetProductByProductId(int ProductId)
        {
            var response = await ps.GetProductByProductId(ProductId);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

        [HttpGet("getProductByProductCode/{ProductCode}")]
        public async Task<ActionResult> GetProductByProductCode(string ProductCode)
        {
            var response = await ps.GetProductByProductCode(ProductCode);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }
    }
}
