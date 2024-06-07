using FluentAssertions;
using Shoeses.persistence.EF;
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
    public class UserServiceGetAllTest
    {
        private readonly UserService _sut;
        private readonly EFDataContext _context;
        private readonly EFDataContext _reaContext;

        public UserServiceGetAllTest()
        {
            var db = new EFInMemoryDatabase();
            _context = db.CreateDataContext<EFDataContext>();
            _reaContext = db.CreateDataContext<EFDataContext>();
            _sut = UserServiceFactory.Create(_context);
        }

        [Fact]
        public async Task GetAll_Returns_All_Users()
        {
            // Arrange
            var user1 = new UserBuilder().WithEmail("user1@example.com").Build();
            var user2 = new UserBuilder().WithEmail("user2@example.com").Build();
            _context.Users.AddRange(user1, user2);
            await _context.SaveChangesAsync();

            // Act
            var result = await _sut.GetAll();

            // Assert
            result.Should().HaveCount(2);
            result.Should().Contain(u => u.Email == "user1@example.com");
            result.Should().Contain(u => u.Email == "user2@example.com");
        }

        [Fact]
        public async Task GetAll_Returns_EmptyList_When_No_Users()
        {
            // Arrange

            // Act
            var result = await _sut.GetAll();

            // Assert
            result.Should().BeEmpty();
        }
    }

}
