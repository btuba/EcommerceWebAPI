using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _service;
        public ImagesController(IImageService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetImages()
        {
            var response = await _service.GetImages();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImage(int id)
        {
            ImageDisplayResponse response = await _service.GetImageById(id);
            return Ok(response);
        }

        [HttpGet("Search/{key}")]
        public async Task<IActionResult> Search(int key)
        {
            var response = await _service.GetImagesByColor(key);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddImageRequest request)
        {
            if (ModelState.IsValid)
            {
                int Id = await _service.AddImage(request);
                return CreatedAtAction(nameof(GetImage), routeValues: new { id = Id }, value: null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateImageRequest request)
        {
            if (await _service.IsImageExist(id))
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateImage(request);
                    return CreatedAtAction(nameof(GetImage), routeValues: new { id = id }, value: null);
                }
                return BadRequest(ModelState);
            }
            return NotFound(new { message = $"{id}'li size bulunamadı." });
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _service.IsImageExist(id))
            {
                await _service.DeleteImage(id);
                return Ok();
            }
            return NotFound(new { message = $"{id}'li image bulunamadı." });
        }
    }
}
