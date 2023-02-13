using Application.Application.Interfaces;
using Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication _productApplication;

        public ProductController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productApplication.GetAll();

            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(string id)
        {
            var product = _productApplication.GetById(id);

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateProductDto product)
        {
            _productApplication.Add(product);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProductDto product)
        {
            _productApplication.Update(product);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _productApplication.Delete(id);

            return Ok();
        }
    }
}
