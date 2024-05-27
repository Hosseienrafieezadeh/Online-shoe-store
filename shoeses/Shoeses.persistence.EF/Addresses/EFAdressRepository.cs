using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shoeses.Entitis.Addresses;
using Shoeses.Entitis.Orders;
using Shoeses.Services.Addresses.Contracts;
using Shoeses.Services.Addresses.Contracts.Dtos;

namespace Shoeses.persistence.EF.Addresses
{
   public class EFAdressRepository: AdressRepository
   {
       private readonly EFDataContext _context;
       public EFAdressRepository(EFDataContext context)
       {
           _context = context;
       }
       public void Add(Address address)
       {
           _context.Addresses.Add(address);
       }

       public void Update(Address address)
       {
           _context.Addresses.Update(address);
       }

       public void Delete(Address address)
       {
           _context.Addresses.Remove(address);
       }

       public Address? Find(int id)
       {
          return _context.Addresses.FirstOrDefault(_ => _.Id == id);
       }

       public async Task<List<GetAdressDto>> GetAll()
       {
           IQueryable<Address> query = _context.Addresses;
           List<GetAdressDto> addresses = await query.Select(address => new GetAdressDto()
           {
               Id = address.Id,
               City = address.City,
               Country = address.Country,
               IsBillingAddress = address.IsBillingAddress,
               IsShippingAddress = address.IsShippingAddress,
               PostalCode = address.PostalCode,
               State = address.State,
               Street = address.Street,
               UserId = address.UserId,
           }).ToListAsync();
           return addresses;
       }

       public bool IsExistUser(string userId)
       {
          return _context.Users.Any(_ => _.Id == userId);
       }
   }
}
