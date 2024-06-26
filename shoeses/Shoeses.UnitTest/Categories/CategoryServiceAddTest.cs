using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shoeses.Entitis.Categoryes;
using Shoeses.Entitis.Promotions;
using Shoeses.persistence.EF;
using Shoeses.persistence.EF.Categoryes;
using Shoeses.persistence.EF.Products;
using Shoeses.Services.Categoryes;
using Shoeses.Services.Categoryes.Contracts;
using Shoeses.Services.Categoryes.Contracts.Exeptions;
using Shoeses.Services.Users.Contracts;
using Shoeses.TestTools.Categories;
using Shoeses.TestTools.Instructure.DataBaseConfig;
using Shoeses.TestTools.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.UnitTest.Categories
{
    //public class CategoryServiceAddTest
    //{
    //    private readonly CategoryService _sut;
    //    private readonly EFDataContext _context;
    //    private readonly EFDataContext _readContext;

    //    public CategoryServiceAddTest()
    //    {
    //        var db = new EFInMemoryDatabase();
    //        _context = db.CreateDataContext<EFDataContext>();
    //        _readContext = db.CreateDataContext<EFDataContext>();
    //        _sut = CategoryServiceFactory.Create(_context);
    //    }

    //    [Fact]
    //    public async Task Add_Adds_New_Category_Properly()
    //    {
    //        // Arrange
    //        var dto = AddCategoryDtoFactory.Create();

    //        // Act
    //        await _sut.Add(dto);

    //        // Assert
    //        var actual = _readContext.Categories.Single();
    //        actual.Name.Should().Be(dto.Name);
    //        actual.Products.Should().HaveCount(1);

    //        var product = actual.Products.First();
    //        product.Name.Should().Be(dto.Products.First().Name);
    //        product.Description.Should().Be(dto.Products.First().Description);
    //        product.Price.Should().Be(dto.Products.First().Price);
    //        product.Count.Should().Be(dto.Products.First().Count);
    //        product.PromotionId.Should().Be(dto.Products.First().PromotionId);
    //    }

    //    [Fact]
    //    public async Task Add_Throws_CategoryNameAlreadyExistException()
    //    {
    //        // Arrange
    //        var dto = AddCategoryDtoFactory.Create();
    //        await _sut.Add(dto);

    //        var dto2 = AddCategoryDtoFactory.Create();
    //        dto2.Name = dto.Name; // Set the same name to create a duplicate category

    //        // Act
    //        Func<Task> act = async () => await _sut.Add(dto2);

    //        // Assert
    //        await act.Should().ThrowAsync<CategoryNameAlreadyExistException>();
    //    }




    public class CategoryServiceAddTest
    {
        private readonly EFDataContext _context;
        private readonly CategoryAppServiec _sut;

        public CategoryServiceAddTest()
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
        public async Task Add_Adds_New_Category_Properly()
        {
            // Arrange
            var dto = AddCategoryDtoFactory.Create();

            // Act
            await _sut.Add(dto);

            // Assert
            var actual = _context.Categories.Include(c => c.Products).Single();
            actual.Name.Should().Be(dto.Name);
            actual.Products.Should().HaveCount(1);

            var product = actual.Products.First();
            product.Name.Should().Be(dto.Products.First().Name);
            product.Description.Should().Be(dto.Products.First().Description);
            product.Price.Should().Be(dto.Products.First().Price);
            product.Count.Should().Be(dto.Products.First().Count);
            product.PromotionId.Should().Be(dto.Products.First().PromotionId);
        }

        [Fact]
        public async Task Add_Throws_CategoryNameAlreadyExistException()
        {
            // Arrange
            var dto = AddCategoryDtoFactory.Create();
            await _sut.Add(dto);

            var dto2 = AddCategoryDtoFactory.Create();
            dto2.Name = dto.Name; // Set the same name to create a duplicate category

            // Act
            Func<Task> act = async () => await _sut.Add(dto2);

            // Assert
            await act.Should().ThrowAsync<CategoryNameAlreadyExistException>();
        }
    }
}
