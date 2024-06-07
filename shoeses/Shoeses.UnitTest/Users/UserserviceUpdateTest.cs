using FluentAssertions;
using Shoeses.persistence.EF;
using Shoeses.Services.Addresses.Contracts.Dtos;
using Shoeses.Services.Users.Contracts;
using Shoeses.Services.Users.Contracts.Dtos;
using Shoeses.Services.Users.Contracts.Exeptions;
using Shoeses.TestTools.Instructure.DataBaseConfig;
using Shoeses.TestTools.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.UnitTest.Users
{
    public class UserserviceUpdateTest
    {
        private readonly UserService _sut;
        private readonly EFDataContext _context;
        private readonly EFDataContext _reaContext;

        public UserserviceUpdateTest()
        {
            var db = new EFInMemoryDatabase();
            _context = db.CreateDataContext<EFDataContext>();
            _reaContext = db.CreateDataContext<EFDataContext>();
            _sut = UserServiceFactory.Create(_context);
        }
      [Fact]
      public async Task Update_Existing_User_Properly()
      {
          // Arrange
          var user = new UserBuilder().Build();
          _context.Users.Add(user);
          await _context.SaveChangesAsync();

          var updateDto = new UpdateUserDto
          {
              FirstName = "UpdatedFirstName",
              LastName = "UpdatedLastName",
              Email = "updatedemail@example.com",
              Addresses = new List<UpdateAdressDto>
              {
                  new UpdateAdressDto
                  {
                      Street = "Updated St",
                      City = "Updated City",
                      State = "Updated State",
                      PostalCode = "Updated Postal",
                      Country = "Updated Country",
                      IsBillingAddress = true,
                      IsShippingAddress = true
                  }
              }
          };

          // Act
          await _sut.Update(user.Id, updateDto);

          // Ensure changes are saved
          await _context.SaveChangesAsync();
          await _reaContext.SaveChangesAsync();

          // Reload the context to ensure changes are committed
          _reaContext.Entry(user).Reload();
          var actual = _reaContext.Users.Single(u => u.Id == user.Id);

          // Assert
          actual.FirstName.Should().Be(updateDto.FirstName);
          actual.LastName.Should().Be(updateDto.LastName);
          actual.Email.Should().Be(updateDto.Email);
          actual.Addresses.Should().HaveCount(1);
          var address = actual.Addresses.First();
          address.Street.Should().Be(updateDto.Addresses.First().Street);
          address.City.Should().Be(updateDto.Addresses.First().City);
          address.State.Should().Be(updateDto.Addresses.First().State);
          address.PostalCode.Should().Be(updateDto.Addresses.First().PostalCode);
          address.Country.Should().Be(updateDto.Addresses.First().Country);
          address.IsBillingAddress.Should().Be(updateDto.Addresses.First().IsBillingAddress);
          address.IsShippingAddress.Should().Be(updateDto.Addresses.First().IsShippingAddress);
      }



        [Fact]
        public async Task Update_Throws_UserNotFoundException_When_User_Does_Not_Exist()
        {
            // Arrange
            var updateDto = new UpdateUserDto
            {
                FirstName = "UpdatedFirstName",
                LastName = "UpdatedLastName",
                Email = "updatedemail@example.com",
                Addresses = new List<UpdateAdressDto>
                {
                    new UpdateAdressDto
                    {
                        Street = "Updated St",
                        City = "Updated City",
                        State = "Updated State",
                        PostalCode = "Updated Postal",
                        Country = "Updated Country",
                        IsBillingAddress = true,
                        IsShippingAddress = true
                    }
                }
            };

            // Act
            Func<Task> act = async () => await _sut.Update("nonexistentuserid", updateDto);

            // Assert
            await act.Should().ThrowExactlyAsync<UserNotFoundException>();
        }
    }
}
