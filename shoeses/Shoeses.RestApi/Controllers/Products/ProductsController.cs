using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoeses.Services.Categoryes.Contracts.Dtos;
using Shoeses.Services.Categoryes;
using Shoeses.Services.Products.Contracts;
using Shoeses.Services.Products.Contracts.Dtos;

namespace Shoeses.RestApi.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _serviec;

        public ProductsController(ProductService serviec)
        {
            _serviec = serviec;
        }


        [HttpPost]
        public async Task Add([FromBody] AddProductDto dto)
        {
            await _serviec.Add(dto);
        }
        [HttpPut("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] UpdateProductDto dto)
        {
            await _serviec.Update(id, dto);
        }
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _serviec.Delete(id);
        }
        [HttpGet]
        public async Task<List<GetProductDto>> GetAll()
        {
            return await _serviec.GetAll();
        }
    }
}
