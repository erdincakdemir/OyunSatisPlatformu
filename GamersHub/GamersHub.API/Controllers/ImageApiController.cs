using BussinessLogicLayer.Abstract;
using Entity.POCO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamersHub.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageApiController : ControllerBase
    {
        IimageService imageService;
        public ImageApiController(IimageService service)
        {
            imageService = service;
        }


        [HttpGet]
        public IActionResult GetImages()
        {
            var result = imageService.Get();
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetImageById(int Id)
        {
            var result = imageService.Get(Id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddImage(Image image)
        {
            var result = imageService.Add(image);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateImage(Image image)
        {
            var result = imageService.Update(image);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteImage(Image image)
        {
            var result = imageService.Delete(image);
            return Ok(result);
        }
    }
}
