using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.Addresses.Contracts.Dtos;

namespace Shoeses.Services.Addresses.Contracts
{
    public interface addressService
    {
        Task Add(AddAdressDto dto);
        Task Update(int id, UpdateAdressDto dto);
        Task Delete(int id);
        Task<List<GetAdressDto>> GetAll();
    }
}
