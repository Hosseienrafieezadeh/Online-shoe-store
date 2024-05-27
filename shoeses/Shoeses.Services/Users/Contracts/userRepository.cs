using Shoeses.Entitis.Addresses;
using Shoeses.Services.Addresses.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Entitis.Users;
using Shoeses.Services.Users.Contracts.Dtos;

namespace Shoeses.Services.Users.Contracts
{
   public interface userRepository
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        User? Find(string userId);
        Task<List<GetUserDto>> GetAll();
        bool IsExistUser(string email);
        bool IsExistAddressThisUser(string userId);
    }
}
