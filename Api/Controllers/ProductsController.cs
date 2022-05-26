using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _service.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            ProductDisplayResponse product = await _service.GetProduct(id);
            return Ok(product);
        }

        [HttpGet("Search/{key}")]
        public async Task<IActionResult> Search(string key)
        {
            var response = await _service.GetProductByName(key);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductRequest request)
        {
            if (ModelState.IsValid)
            {
                int productId = await _service.AddProduct(request);
                return CreatedAtAction(nameof(GetProduct), routeValues: new { id = productId }, value: null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductRequest request)
        {
            if(await _service.IsProductExist(id))
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateProduct(request);
                    return CreatedAtAction(nameof(GetProduct), routeValues: new { id = id }, value: null);
                }
                return BadRequest(ModelState);
            }
            return NotFound(new { message = $"{id}'li ürün bulunamadı." });
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(await _service.IsProductExist(id))
            {
                await _service.DeleteProduct(id);
                return Ok();
            }
            return NotFound(new { message = $"{id}'li ürün bulunamadı." });
        }

        [HttpPost("AddSize/{id}")]
        public async Task<IActionResult> AddSizeToProduct(int sizeId, int productId)
        {
            await _service.AddSizeToProduct(sizeId, productId);
            return CreatedAtAction(nameof(GetProduct),routeValues: new { id = productId }, value: null);
        }
    }
}
