using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Muhanad.Core.Service.Contract;
using Store.Muhanad.Service.Services.Products;

namespace Store.Muhanad.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet] //GET BaseUrl/api/Product
        public async Task<IActionResult> GetAllProducts()
        {
            var result =await _productService.GetAllProductsAsync();
            return Ok(result);
        }

        [HttpGet("brands")] //GET BaseUrl/api/Product/brands
        public async Task<IActionResult> GetAllBrands()
        {
            var result =await _productService.GetAllBrandsAsync();
            return Ok(result);
        }

        [HttpGet("types")] //GET BaseUrl/api/Product/brands
        public async Task<IActionResult> GetAllTypes()
        {
            var result = await _productService.GetAllTypesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int? id)
        {
            if (id is null) return BadRequest("ID is Invalid");
            var result =await _productService.GetProductById(id.Value);
            if (result == null) return BadRequest($"Product of id:{id} not found");
            return Ok(result);
        }
    }
}
