using BussinessLogicLayer.Abstract;
using Entity.POCO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamersHub.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameCategoryApiController : ControllerBase
    {
        IGameCategoryService gameCategoryService;
        public GameCategoryApiController(IGameCategoryService service)
        {
            gameCategoryService = service;
        }


        [HttpGet]
        public IActionResult GetGameCategories()
        {
            var result = gameCategoryService.Get();
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetGameCategoryById(int Id)
        {
            var result = gameCategoryService.Get(Id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddGameCategory(GameCategory gameCategory)
        {
            var result = gameCategoryService.Add(gameCategory);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateGameCategory(GameCategory gameCategory)
        {
            var result = gameCategoryService.Update(gameCategory);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteGameCategory(GameCategory gameCategory)
        {
            var result = gameCategoryService.Delete(gameCategory);
            return Ok(result);
        }
    }
}
