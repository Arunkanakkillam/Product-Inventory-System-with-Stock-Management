using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViknCodesArun.Bll.Dtos;
using ViknCodesArun.Bll.Services;
using ViknCodesArun.Dll.Models;

namespace ViknCodesArun.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceClass _serviceclass;
            
        public ProductController(IServiceClass serviceClass)
        {
            _serviceclass = serviceClass;
        }
        [HttpGet("listproducts")]
        public async Task<IActionResult> Get() 
        {
            var data= await _serviceclass.ListProduct();
            if (data == null) 
            {
                return NotFound();  
            }
            return Ok(data);
        }
        [HttpPost("createproduct")]
        public async Task<IActionResult>PostProduct([FromBody] ProductDto createProduct)
        {
            var data= await _serviceclass.CreateProduct(createProduct);
            if (data==null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
        [HttpPut("addstock")]
        public async Task<IActionResult> addingstock(int subVariantId, decimal quantity)
        {
            var data= await _serviceclass.AddStock(subVariantId, quantity);
            if (data)
            {
                return Ok(data);
            }
            return BadRequest();
        }
        [HttpPut("removestock")]
        public async Task<IActionResult> removingstock(int subVariantId, decimal quantity)
        {
            var data = await _serviceclass.RemoveStock(subVariantId, quantity);
            if (data)
            {
                return Ok(data);
            }
            return BadRequest();
        }
    }
}
