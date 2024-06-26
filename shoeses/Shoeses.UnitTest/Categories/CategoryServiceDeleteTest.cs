using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Shoeses.persistence.EF.Categoryes;
using Shoeses.persistence.EF.Products;
using Shoeses.persistence.EF;
using Shoeses.Services.Categoryes;
using Shoeses.Services.Categoryes.Contracts.Dtos;
using Shoeses.Services.Categoryes.Contracts.Exeptions;
using Shoeses.TestTools.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.UnitTest.Categories
{
    public class CategoryServiceDeleteTest
    {
        private readonly EFDataContext _context;
        private readonly CategoryAppServiec _sut;

        public CategoryServiceDeleteTest()
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
        public async Task Delete_Deletes_Category_Properly()
        {
            // Arrange
            var dto = AddCategoryDtoFactory.Create();
            await _sut.Add(dto);
            var categoryId = _context.Categories.First().Id;

            // Act
            await _sut.Delete(categoryId);

            // Assert
            _context.Categories.Should().BeEmpty();
        }

        [Fact]
        public async Task Delete_Throws_CategoryNotFoundException()
        {
            // Act
            Func<Task> act = async () => await _sut.Delete(999); // Using a non-existent ID

            // Assert
            await act.Should().ThrowAsync<CategoryNotFoundException>();
        }

    }
}
