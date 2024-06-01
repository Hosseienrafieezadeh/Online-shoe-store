using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoeses.Services.Categoryes;
using Shoeses.Services.Categoryes.Contracts.Dtos;
using Shoeses.Services.Users.Contracts.Dtos;
using Shoeses.Services.Users.Contracts;

namespace Shoeses.RestApi.Controllers.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryAppServiec _serviec;

        public CategoryController(CategoryAppServiec serviec)
        {
            _serviec = serviec;
        }

     
        [HttpPost]
        public async Task Add([FromBody] AddCategoryDto dto)
        {
            await _serviec.Add(dto);
        }
        [HttpPut("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] UpdateCategoriesDto dto)
        {
            await _serviec.Update(id, dto);
        }
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _serviec.Delete(id);
        }
        [HttpGet]
        public async Task<List<GetCategoryDto>> GetAll()
        {
            return await _serviec.GetAll();
        }
    }
}
