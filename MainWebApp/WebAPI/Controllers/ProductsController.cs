using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IService;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IService<Product> _productService;

        public ProductsController(IService<Product> productService)
        {
            this._productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAll();
            if (result == null)
                return BadRequest("Error");

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _productService.Get(id);
            if (result == null)
                return BadRequest("Error");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product model)
        {
            var result = await _productService.Insert(model);
            if (result)
                return Ok("Success");

            return BadRequest("Error");
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product model)
        {
            var result = await _productService.Update(model);
            if (result)
                return Ok("Success");

            return BadRequest("Error");
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Product? model = await _productService.Get(id);
            if (model == null)
                return BadRequest("Error");

            var result = await _productService.Update(model);
            if (result)
                return Ok("Success");

            return BadRequest("Error");
        }

    }
}
