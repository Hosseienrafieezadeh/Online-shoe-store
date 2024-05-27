using Shoeses.Services.Addresses.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.Users.Contracts.Dtos;

namespace Shoeses.Services.Users.Contracts
{
    public interface UserService
    {
        Task Add(AddUserDto dto);
        Task Update(string Id, UpdateUserDto dto);
        Task Delete(string id);
        Task<List<GetUserDto>> GetAll();
    }
}
