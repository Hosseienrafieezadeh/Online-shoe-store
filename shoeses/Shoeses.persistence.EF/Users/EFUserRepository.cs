using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shoeses.Entitis.Addresses;
using Shoeses.Entitis.Users;
using Shoeses.Services.Addresses.Contracts.Dtos;
using Shoeses.Services.Users.Contracts;
using Shoeses.Services.Users.Contracts.Dtos;

namespace Shoeses.persistence.EF.Users
{
    public class EFUserRepository:userRepository
    {
        private readonly EFDataContext _context;

        public EFUserRepository(EFDataContext context )
        {
            _context = context;
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public User? Find(string userId)
        {
           return _context.Users.FirstOrDefault(_ => _.Id == userId);
        }

        public async Task<List<GetUserDto>> GetAll()
        {
            IQueryable<User> query = _context.Users;
            List<GetUserDto> users = await query.Select(user => new GetUserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Adress = _context.Addresses
                    .Where(a => a.UserId == user.Id)
                    .Select(a => new GetAdressDto()
                    {
                        Id = a.Id,
                        Street = a.Street,
                        City = a.City,
                        State = a.State,
                        PostalCode = a.PostalCode,
                        Country = a.Country,
                        IsBillingAddress = a.IsBillingAddress,
                        IsShippingAddress = a.IsShippingAddress
                    }).FirstOrDefault() // اگر آدرسی وجود نداشت، null برمی‌گرداند
            }).ToListAsync();

            return users;
        }


        public bool IsExistUser(string email)
        {
            return _context.Users.Any(_ => _.Email == email);
        }

        public bool IsExistAddressThisUser(string userId)
        {
            return _context.Addresses.Any(a => a.UserId == userId);
        }
    }
}
