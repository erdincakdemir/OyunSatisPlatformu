using BussinessLogicLayer.Abstract;
using Entity.POCO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamersHub.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartApiController : ControllerBase
    {
        ICartService cartService;
        public CartApiController(ICartService service)
        {
            cartService = service;
        }


        [HttpGet]
        public IActionResult GetCarts()
        {
            var result = cartService.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCartById(int Id)
        {
            var result = cartService.Get(Id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCart(Cart cart)
        {
            var result = cartService.Add(cart);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateCart(Cart cart)
        {
            var result = cartService.Update(cart);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteCart(Cart cart)
        {
            var result = cartService.Delete(cart);
            return Ok(result);
        }
    }
}
