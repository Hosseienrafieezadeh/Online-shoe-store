using Microsoft.EntityFrameworkCore;
using Shoeses.persistence.EF.Categoryes;
using Shoeses.persistence.EF.Products;
using Shoeses.persistence.EF;
using Shoeses.Services.Categoryes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Shoeses.Services.Categoryes.Contracts.Dtos;
using Shoeses.Services.Categoryes.Contracts.Exeptions;
using Shoeses.TestTools.Categories;

namespace Shoeses.UnitTest.Categories
{
    public class CategoryServiceUpdateTest
    {
        private readonly EFDataContext _context;
        private readonly CategoryAppServiec _sut;

        public CategoryServiceUpdateTest()
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
        public async Task Update_Updates_Category_Properly()
        {
            // Arrange
            var dto = AddCategoryDtoFactory.Create();
            await _sut.Add(dto);

            var updateDto = new UpdateCategoriesDto
            {
                Name = "Updated Category"
            };

            // Act
            await _sut.Update(_context.Categories.First().Id, updateDto);

            // Assert
            var actual = _context.Categories.Single();
            actual.Name.Should().Be(updateDto.Name);
        }

        [Fact]
        public async Task Update_Throws_CategoryNotFoundExceptionToUpdate()
        {
            // Arrange
            var updateDto = new UpdateCategoriesDto
            {
                Name = "Updated Category"
            };

            // Act
            Func<Task> act = async () => await _sut.Update(999, updateDto); // Using a non-existent ID

            // Assert
            await act.Should().ThrowAsync<CategoryNotFoundExceptionToUpdate>();
        }
    }
}
