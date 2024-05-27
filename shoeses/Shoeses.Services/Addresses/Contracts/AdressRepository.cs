using Shoeses.Entitis.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Entitis.Addresses;
using Shoeses.Services.Addresses.Contracts.Dtos;

namespace Shoeses.Services.Addresses.Contracts
{
    public interface AdressRepository
    {
        void Add(Address address);
        void Update(Address address);
        void Delete(Address address);
        Address? Find(int id);
        Task<List<GetAdressDto>> GetAll();
        bool IsExistUser(string userId);
        
    }
}
