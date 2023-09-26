using BussinessLogicLayer.Abstract;
using BussinessLogicLayer.Concreate;
using DataAccessLayer.Concreate.AdoNet;
using Entity.POCO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamersHub.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameApiController : ControllerBase
    {
        IGameService gameService;
        public GameApiController(IGameService service)
        {
            gameService = service;
        }


        [HttpGet]
        public IActionResult GetGames()
        {
            var result = gameService.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetGameById(int Id)
        {
            var result = gameService.Get(Id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddGame(Game game)
        {
            var result = gameService.Add(game);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateGame(Game game)
        {
            var result = gameService.Update(game);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteGame(Game game)
        {
            var result = gameService.Delete(game);
            return Ok(result);
        }
    }
}
