using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Entities;
using ProductCatalog.Extensions;
using ProductCatalog.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ProductCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = nameof(Role.Admin))]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly Context _context;

        public ProductCategoriesController(Context context)
        {
            _context = context;
        }

        // GET: api/ProductCategories
        [HttpGet]
        public async Task<IEnumerable<ProductCategoryModel>> GetProductCategories()
        {
            return await _context.ProductCategories.Where(d => !d.IsDeleted)
                .Select(x => new ProductCategoryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                })
                .ToListAsync();
        }

        // GET: api/ProductCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategoryModel>> GetProductCategory(int id)
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);
            if (!productCategory.Exist()) return NotFound();

            return new ProductCategoryModel
            {
                Id = productCategory.Id,
                Name = productCategory.Name,
                Description = productCategory.Description
            };
     
        }

        // PUT: api/ProductCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCategory(int id, ProductCategoryPutModel productCategoryModel)
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);
            if (!productCategory.Exist()) return NotFound();

            productCategory.Name = productCategoryModel.Name;
            productCategory.Description = productCategoryModel.Description;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/ProductCategories

        [HttpPost]
        public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategoryPutModel productCategoryModel)
        {

            var entity = _context.ProductCategories.Add(new ProductCategory
            {
                Name = productCategoryModel.Name,
                Description = productCategoryModel.Description
            });
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductCategory), new { id = entity.Entity.Id }, productCategoryModel);
        }

        // DELETE: api/ProductCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductCategory>> DeleteProductCategory(int id)
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);
            if (!productCategory.Exist()) return NotFound();

            productCategory.IsDeleted = true;
            await _context.SaveChangesAsync();

            return productCategory;
        }

    }
}
