using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ISizeService _service;
        
        public SizesController(ISizeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetSizes()
        {
            var response = await _service.GetSizes();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSize(int id)
        {
            SizeDisplayResponse response = await _service.GetSizeById(id);
            return Ok(response);
        }

        [HttpGet("Search/{key}")]
        public async Task<IActionResult> Search(string key)
        {
            var response = await _service.GetSizesByData(key);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddSizeRequest request)
        {
            if (ModelState.IsValid)
            {
                int Id = await _service.AddSize(request);
                return CreatedAtAction(nameof(GetSize), routeValues: new { id = Id }, value: null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateSizeResponse request)
        {
            if (await _service.IsSizeExist(id))
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateSize(request);
                    return CreatedAtAction(nameof(GetSize), routeValues: new { id = id }, value: null);
                }
                return BadRequest(ModelState);
            }
            return NotFound(new { message = $"{id}'li size bulunamadı." });
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _service.IsSizeExist(id))
            {
                await _service.DeleteSize(id);
                return Ok();
            }
            return NotFound(new { message = $"{id}'li size bulunamadı." });
        }
    }
}
