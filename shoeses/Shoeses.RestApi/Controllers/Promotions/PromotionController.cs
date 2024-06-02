using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoeses.Services.Promotions.Contracts.Dtos;
using Shoeses.Services.Promotions.Contracts;

namespace Shoeses.RestApi.Controllers.Promotions
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly PromotionService _promotionService;

        public PromotionController(PromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpPost]
        public async Task  Add([FromBody] AddPromotionDto dto)
        {
            await _promotionService.Add(dto);
         
        }

        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] UpdatePromotionDto dto)
        {
            await _promotionService.Update(id, dto);
         
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _promotionService.Delete(id);
          
        }

        [HttpGet]
        public async Task<List<GetPromotionDto>> GetAll()
        {
        return await _promotionService.GetAll();
           
        }

        [HttpGet("{id}")]
        public async Task<GetPromotionDto> GetById(int id)
        {
          return  await _promotionService.GetById(id);
         
        }
    }
}
