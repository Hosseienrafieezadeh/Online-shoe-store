using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoeses.Services.Categoryes.Contracts.Dtos;
using Shoeses.Services.Categoryes;
using Shoeses.Services.Reviews.Contracts;
using Shoeses.Services.Reviews.Contracts.Dtos;

namespace Shoeses.RestApi.Controllers.Reviews
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _serviec;

        public ReviewController(ReviewService serviec)
        {
            _serviec = serviec;
        }


        [HttpPost]
        public async Task Add([FromBody] AddReviewDto dto)
        {
            await _serviec.Add(dto);
        }
        [HttpPut("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] UpdateReviewDto dto)
        {
            await _serviec.Update(id, dto);
        }
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _serviec.Delete(id);
        }
        [HttpGet]
        public async Task<List<GetReviewsDto>> GetAll()
        {
            return await _serviec.GetAll();
        }
    }
}
