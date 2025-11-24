using ECommerce.Business.Abstract;
using ECommerce.Business.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return new ObjectResult(products) { StatusCode = products.StatusCode };
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDto productCreateDto)
        {
            var product = await _productService.CreateProductAsync(productCreateDto);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return product == null ? NotFound("İlgili ürün bulunamadı") : Ok(product);
        }


        [HttpGet("low")]
        public async Task<IActionResult> GetLowStockProducts([FromQuery] int thresold)
        {
            var products = await _productService.GetLowStockProductsAsync(thresold);
            return Ok(products);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductUpdateDto productUpdateDto)
        {
            await _productService.UpdateProductAsync(id, productUpdateDto);
            return Ok();
        }

    }
}
