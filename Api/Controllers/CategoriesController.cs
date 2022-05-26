using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _service.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            CategoryDisplayResponse category = await _service.GetCategoryById(id);
            return Ok(category);
        }

        /*[HttpGet("Search/{key}")]
        public async Task<IActionResult> Search(string key)
        {
            var response = await _service.GetCategoriesByName(key);
            return Ok(response);
        }*/

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                int Id = await _service.AddCategory(request);
                return CreatedAtAction(nameof(GetCategory), routeValues: new { id = Id }, value: null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryRequest request)
        {
            if (await _service.IsCategoryExist(id))
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateCategory(request);
                    return CreatedAtAction(nameof(GetCategory), routeValues: new { id = id }, value: null);
                }
                return BadRequest(ModelState);
            }
            return NotFound(new { message = $"{id}'li ürün bulunamadı." });
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _service.IsCategoryExist(id))
            {
                await _service.DeleteCategory(id);
                return Ok();
            }
            return NotFound(new { message = $"{id}'li kategori bulunamadı." });
        }
    }
}
