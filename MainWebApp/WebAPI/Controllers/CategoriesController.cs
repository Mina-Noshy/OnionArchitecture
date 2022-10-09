using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IService;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IService<Category> _categoryService;

        public CategoriesController(IService<Category> categoryService)
        {
            this._categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAll();
            if (result == null)
                return BadRequest("Error");

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoryService.Get(id);
            if (result == null)
                return BadRequest("Error");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category model)
        {
            var result = await _categoryService.Insert(model);
            if (result)
                return Ok("Success");

            return BadRequest("Error");
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category model)
        {
            var result = await _categoryService.Update(model);
            if (result)
                return Ok("Success");

            return BadRequest("Error");
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Category? model = await _categoryService.Get(id);
            if (model == null)
                return BadRequest("Error");

            var result = await _categoryService.Update(model);
            if (result)
                return Ok("Success");

            return BadRequest("Error");
        }

    }
}
