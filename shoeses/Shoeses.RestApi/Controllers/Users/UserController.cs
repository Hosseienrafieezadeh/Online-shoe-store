using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoeses.Services.Users;
using Shoeses.Services.Users.Contracts;
using Shoeses.Services.Users.Contracts.Dtos;

namespace Shoeses.RestApi.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task Add([FromBody] AddUserDto dto)
        {
            await _service.Add(dto);
        }
        [HttpPut("{id}")]
        public async Task Update([FromRoute] string id, [FromBody] UpdateUserDto dto)
        {
            await _service.Update(id, dto);
        }
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] string id)
        {
            await _service.Delete(id);
        }
        [HttpGet]
        public async Task<List<GetUserDto>> GetAll()
        {
            return await _service.GetAll();
        }
    }
}
