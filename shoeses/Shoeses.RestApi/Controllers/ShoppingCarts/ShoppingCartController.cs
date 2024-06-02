using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoeses.Services.ShoppingCarts.Contracts;
using Shoeses.Services.ShoppingCarts.Contracts.Dtos;
using Shoeses.Services.ShoppingCarts.Contracts.Exeptions;

namespace Shoeses.RestApi.Controllers.ShoppingCarts
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ShoppingCartService _shoppingCartService;

        public ShoppingCartController(ShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        [HttpPost]
        public async Task Add([FromBody] AddShoppingCartDto dto)
        {
            await _shoppingCartService.Add(dto);
            
        }

        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] UpdateShoppingCartDto dto)
        {

            await _shoppingCartService.Update(id, dto);

        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           
           
                await _shoppingCartService.Delete(id);
         
        }

        [HttpGet]
        public async Task<List<GetShoppingCartDto>> GetAll()
        {
            return  await _shoppingCartService.GetAll();
           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetShoppingCartDto>> GetById(int id)
        {
        
                 return await _shoppingCartService.GetById(id);
                
       
        }
    }


}
