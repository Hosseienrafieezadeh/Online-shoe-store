using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Shoeses.persistence.EF;
using Shoeses.Services.Addresses.Contracts.Dtos;
using Shoeses.Services.Users.Contracts;
using Shoeses.Services.Users.Contracts.Exeptions;
using Shoeses.TestTools.Instructure.DataBaseConfig;
using Shoeses.TestTools.Users;

namespace Shoeses.UnitTest.Users
{
   public class UsersServiceAddTest
   {
         private readonly UserService _sut;
           private readonly EFDataContext _context;
            private readonly EFDataContext _reaContext;

            public UsersServiceAddTest()
            {
                var db = new EFInMemoryDatabase();
                _context = db.CreateDataContext<EFDataContext>();
                _reaContext = db.CreateDataContext<EFDataContext>();
                _sut = UserServiceFactory.Create(_context);
            }

            [Fact]
            public async Task Add_New_User_propely()
            {
                var dto = AddUserDtoFactory.Create();
                await _sut.Add(dto);
                var actual = _reaContext.Users.Single();
                actual.FirstName.Should().Be(dto.FirstName);
                actual.LastName.Should().Be(dto.LastName);
                actual.Email.Should().Be(dto.Email);
            }

            [Fact]
            public async Task Add_throsws_UserIsNotExistException()
            {
                var dto1 = AddUserDtoFactory.Create();
                await _sut.Add(dto1);
                var dto2 = AddUserDtoFactory.Create();
                var actual = async () => await _sut.Add(dto2);
                await actual.Should().ThrowExactlyAsync<UsersIsNotExistException>();
            }
        [Fact]
        public async Task Add_User_With_Addresses()
        {
            var addresses = new List<AddAdressDto>
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
                }
            };
            var dto = AddUserDtoFactory.Create(email: "user2@example.com", addresses: addresses);
            await _sut.Add(dto);
            var actual = _reaContext.Users.Include(u => u.Addresses).Single();
            actual.FirstName.Should().Be(dto.FirstName);
            actual.LastName.Should().Be(dto.LastName);
            actual.Email.Should().Be(dto.Email);
            actual.Addresses.Should().HaveCount(1);
            var actualAddress = actual.Addresses.Single();
            actualAddress.Street.Should().Be(addresses[0].Street);
            actualAddress.City.Should().Be(addresses[0].City);
            actualAddress.State.Should().Be(addresses[0].State);
            actualAddress.PostalCode.Should().Be(addresses[0].PostalCode);
            actualAddress.Country.Should().Be(addresses[0].Country);
            actualAddress.IsBillingAddress.Should().Be(addresses[0].IsBillingAddress);
            actualAddress.IsShippingAddress.Should().Be(addresses[0].IsShippingAddress);
        }

        [Fact]
        public async Task Add_User_Without_Addresses()
        {
            var dto = AddUserDtoFactory.Create(email: "user3@example.com", addresses: new List<AddAdressDto>());
            await _sut.Add(dto);
            var actual = _reaContext.Users.Include(u => u.Addresses).Single();
            actual.FirstName.Should().Be(dto.FirstName);
            actual.LastName.Should().Be(dto.LastName);
            actual.Email.Should().Be(dto.Email);
            actual.Addresses.Should().BeEmpty();
        }

        [Fact]
        public async Task Add_Throws_Exception_When_Email_Is_Duplicate()
        {
            var dto1 = AddUserDtoFactory.Create(email: "duplicate@example.com");
            await _sut.Add(dto1);
            var dto2 = AddUserDtoFactory.Create(email: "duplicate@example.com"); // ایمیل تکراری
            Func<Task> act = async () => await _sut.Add(dto2);
            await act.Should().ThrowExactlyAsync<UsersIsNotExistException>();
        }
    }
}
