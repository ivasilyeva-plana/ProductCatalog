using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Controllers;
using ProductCatalog.Entities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ProductCatalog.Tests
{
    public class ProductCategoriesControllerTests
    {
        [Fact]
        public async Task GetProductCategoriesReturnsAResponseWithAListOfProductCategories()
        {
            var dbContext = GetDbContext();
            var controller = new ProductCategoriesController(dbContext);

            var result = await controller.GetProductCategories();

            var resultArray = result.ToArray();
            resultArray.Should().NotBeNull();
            resultArray.Should().HaveCount(1);

            var resultModel = resultArray.First();
            var entity = dbContext.ProductCategories.Find(1);

            resultModel.Id.Should().Be(entity.Id);
            resultModel.Name.Should().Be(entity.Name);
            resultModel.Description.Should().Be(entity.Description);
        }

        private Context GetDbContext()
        {
            var dbContext = new Context(new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase("TestDb")
                .Options);

            SeedDatabase(dbContext);

            return dbContext;
        }

        private void SeedDatabase(Context dbContext)
        {
            dbContext.ProductCategories.AddRange(
                new ProductCategory
                    {Id = 1, Name = "Category 1", Description = "description 1", IsDeleted = false},
                new ProductCategory
                    {Id = 2, Name = "Category 2", Description = "description 2", IsDeleted = true});

            dbContext.SaveChanges();
        }
    }
}
