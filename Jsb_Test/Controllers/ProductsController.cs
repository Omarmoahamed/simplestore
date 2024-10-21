using Jsb_Test.BL;
using Jsb_Test.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jsb_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        public IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var list = await _productService.GetProducts();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getproduct(int id)
        {
            var pr = await _productService.GetProductById(id);
            return pr == null ? NotFound("Product is not found") : Ok(pr);
        }

        [HttpPost]
        public async Task<ActionResult> Addproduct([FromBody] Product product)
        {
            var p = await _productService.AddProduct(product);

            return p == true ? Ok("Product is successfully Added") : BadRequest(new { Message = "Please write correct fields" });
        }

        [HttpPost("{id}")]

        public async Task<ActionResult> UpdateProduct(int id, [FromBody] Product pr)
        {
            var p = await _productService.UpdateProduct(id, pr);

            return p == true ? Ok("product is successfully updated") : BadRequest(new { message = "Product could be missing or something in fields is missing" });
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteProduct(int id) 
        {
            var p = await _productService.DeleteProduct(id);

            return p == true ? Ok("Product is deleted successfully") : BadRequest(new { message = "Product is not found " });

        }
    }
}
