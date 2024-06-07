using FluentAssertions;
using Shoeses.persistence.EF;
using Shoeses.Services.Users.Contracts.Exeptions;
using Shoeses.Services.Users.Contracts;
using Shoeses.TestTools.Instructure.DataBaseConfig;
using Shoeses.TestTools.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.UnitTest.Users
{
    public class UserServiceDeleteTest
    {
        private readonly UserService _sut;
        private readonly EFDataContext _context;
        private readonly EFDataContext _reaContext;

        public UserServiceDeleteTest()
        {
            var db = new EFInMemoryDatabase();
            _context = db.CreateDataContext<EFDataContext>();
            _reaContext = db.CreateDataContext<EFDataContext>();
            _sut = UserServiceFactory.Create(_context);
        }

        [Fact]
        public async Task Delete_Existing_User_Properly()
        {
            // Arrange
            var user = new UserBuilder().Build();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Act
            await _sut.Delete(user.Id);

            // Ensure changes are saved
            await _context.SaveChangesAsync();
            await _reaContext.SaveChangesAsync();

            // Assert
            _reaContext.Users.Should().BeEmpty();
            _reaContext.Addresses.Should().BeEmpty();
        }

        [Fact]
        public async Task Delete_Throws_UserNotFoundException()
        {
            // Arrange
            var nonExistentUserId = "non-existent-id";

            // Act
            Func<Task> act = async () => await _sut.Delete(nonExistentUserId);

            // Assert
            await act.Should().ThrowExactlyAsync<UserNotFoundException>();
        }
    }

}
