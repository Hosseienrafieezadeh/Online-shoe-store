using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.Addresses.Contracts.Dtos;
using Shoeses.Services.Users.Contracts.Dtos;

namespace Shoeses.TestTools.Users
{
    public static class AddUserDtoFactory
    {
        public static AddUserDto Create(string? email=null, List<AddAdressDto>? addresses = null)
        {
            return  new AddUserDto()
            {
                Email = email ?? "ali@gmail.com",
                FirstName = "ali",
                LastName = "alizadeh",
                Addresses = addresses ?? new List<AddAdressDto>
                {
                    new AddAdressDto()
                    {
                        Street = "Main St",
                        City = "Tehran",
                        State = "Tehran",
                        PostalCode = "12345",
                        Country = "Iran",
                        IsBillingAddress = true,
                        IsShippingAddress = true
                    },
                    new AddAdressDto()
                    {
                        Street = "Second St",
                        City = "Tehran",
                        State = "Tehran",
                        PostalCode = "67890",
                        Country = "Iran",
                        IsBillingAddress = false,
                        IsShippingAddress = true
                    }

        }
            };
        }
    }
}