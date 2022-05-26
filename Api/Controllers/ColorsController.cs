using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _service;
        public ColorsController(IColorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetColors()
        {
            var response = await _service.GetColors();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColor(int id)
        {
            ColorDisplayResponse response = await _service.GetColorById(id);
            return Ok(response);
        }

        [HttpGet("Search/{key}")]
        public async Task<IActionResult> Search(string key)
        {
            var response = await _service.GetColorsByName(key);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddColorRequest request)
        {
            if (ModelState.IsValid)
            {
                int Id = await _service.AddColor(request);
                return CreatedAtAction(nameof(GetColor), routeValues: new { id = Id }, value: null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateColorRequest request)
        {
            if (await _service.IsColorExist(id))
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateColor(request);
                    return CreatedAtAction(nameof(GetColor), routeValues: new { id = id }, value: null);
                }
                return BadRequest(ModelState);
            }
            return NotFound(new { message = $"{id}'li color bulunamadı." });
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _service.IsColorExist(id))
            {
                await _service.DeleteColor(id);
                return Ok();
            }
            return NotFound(new { message = $"{id}'li color bulunamadı." });
        }
    }
}
