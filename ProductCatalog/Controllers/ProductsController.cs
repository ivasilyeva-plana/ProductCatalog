using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Entities;
using ProductCatalog.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ProductCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User, Admin")]
    public class ProductsController : ControllerBase
    {
        private readonly Context _context;

        public ProductsController(Context context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            return await _context.Products
                .Select(x => new ProductModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Specification = x.Specification,
                    ProductCategory = new ProductCategoryModel
                    {
                        Id = x.ProductCategory.Id,
                        Name = x.ProductCategory.Name,
                        Description = x.ProductCategory.Description
                    }
                })
                .ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProductModel(int id)
        {
            var productModel = await _context.Products
                .Where(i=> i.Id ==id)
                .Select(x => new ProductModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Specification = x.Specification,
                    ProductCategory = new ProductCategoryModel
                    {
                        Id = x.ProductCategory.Id,
                        Name = x.ProductCategory.Name,
                        Description = x.ProductCategory.Description
                    }
                })
                .FirstOrDefaultAsync();

            if (productModel == null)
            {
                return NotFound();
            }

            return productModel;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductModel(int id,
            ProductPutModel productModel)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null) return NotFound();

            product.ProductCategoryId = productModel.ProductCategoryId;
            product.Specification = productModel.Specification;
            product.Name = productModel.Name;
            product.Description = productModel.Description;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProductModel(ProductPutModel productModel)
        {
            var entity = _context.Products.Add(new Product
            {
                ProductCategoryId = productModel.ProductCategoryId,
                Specification = productModel.Specification,
                Name = productModel.Name,
                Description = productModel.Description
            });
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductModel), new {id = entity.Entity.Id}, productModel);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProductModel(int id)
        {
            var productModel = await _context.Products.FindAsync(id);
            if (productModel is null) return NotFound();

            _context.Products.Remove(productModel);
            await _context.SaveChangesAsync();

            return productModel;
        }
    }
}
