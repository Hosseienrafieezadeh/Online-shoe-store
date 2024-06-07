using Shoeses.Entitis.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Entitis.Addresses;
using Shoeses.Services.Addresses.Contracts.Dtos;

namespace Shoeses.TestTools.Users
{
    public class UserBuilder
    {
        private readonly User _user;

        public UserBuilder(string? email = null, List<Address>? addresses = null)
        {
            _user = new User
            {
                Email = email ?? "ali@gmail.com",
                FirstName = "ali",
                LastName = "alizadeh",
                Addresses = addresses ?? new List<Address>
                {
                    new Address
                    {
                        Street = "Main St",
                        City = "Tehran",
                        State = "Tehran",
                        PostalCode = "12345",
                        Country = "Iran",
                        IsBillingAddress = true,
                        IsShippingAddress = true
                    },
                    new Address
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

        public UserBuilder WithEmail(string email)
        {
            _user.Email = email;
            return this;
        }

        public UserBuilder WithFirstName(string firstName)
        {
            _user.FirstName = firstName;
            return this;
        }

        public UserBuilder WithLastName(string lastName)
        {
            _user.LastName = lastName;
            return this;
        }

        public UserBuilder WithAddresses(List<Address> addresses)
        {
            _user.Addresses = addresses;
            return this;
        }

        public User Build()
        {
            return _user;
        }
    }
}
