using Microsoft.EntityFrameworkCore;
using Shoeses.persistence.EF.Categoryes;
using Shoeses.persistence.EF.Products;
using Shoeses.persistence.EF;
using Shoeses.Services.Categoryes;
using Shoeses.TestTools.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Shoeses.UnitTest.Categories
{
    public class CategoryServiceGetAllTest
    {
        private readonly EFDataContext _context;
        private readonly CategoryAppServiec _sut;

        public CategoryServiceGetAllTest()
        {
            var options = new DbContextOptionsBuilder<EFDataContext>()
                .UseInMemoryDatabase(databaseName: "ShoeTestDb")
                .Options;

            _context = new EFDataContext(options);

            var categoryRepository = new EFCategoryesRepository(_context);
            var productRepository = new EFProductRepository(_context);
            var unitOfWork = new EFUnitOfWork(_context);

            _sut = new CategoryAppServiec(categoryRepository, unitOfWork, productRepository);
        }
        [Fact]
        public async Task GetAll_Returns_All_Categories()
        {
            // Arrange
            var dto1 = AddCategoryDtoFactory.Create();
            var dto2 = AddCategoryDtoFactory.Create();
            dto2.Name = "Another Category";

            await _sut.Add(dto1);
            await _sut.Add(dto2);

            // Act
            var categories = await _sut.GetAll();

            // Assert
            categories.Should().HaveCount(2);
            categories.First().Name.Should().Be(dto1.Name);
            categories.Last().Name.Should().Be(dto2.Name);
        }
    }

}
