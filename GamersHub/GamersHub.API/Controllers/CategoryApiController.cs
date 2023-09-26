using BussinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using Entity.POCO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamersHub.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        ICategoryService categoryService;
        public CategoryApiController(ICategoryService service)
        {
            categoryService = service;
        }


        [HttpGet]
        public IActionResult GetCategories()
        {
            var result = categoryService.Get();
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetCategoryById(int Id)
        {
            var result = categoryService.Get(Id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            var result = categoryService.Add(category);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            var result = categoryService.Update(category);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteCategory(Category category)
        {
            var result = categoryService.Delete(category);
            return Ok(result);
        }
    }
}
