using LuxeLoft.Server.Data.Context;
using LuxeLoft.Server.Data.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LuxeLoft.Server.Controllers
{
    /// <summary>
    /// The controller for the product ratings in the database.
    /// </summary>
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductRatingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductRatingController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all the product ratings from the database.
        /// </summary>
        /// <returns>All product ratings.</returns>
        [HttpGet(Name = "GetProductRatings")]
        public async Task<ActionResult<IEnumerable<ProductRatings>>> GetProductRatings()
        {
            return await _context.ProductRatings.ToListAsync();
        }

        /// <summary>
        /// Get a product rating by its id.
        /// </summary>
        /// <returns>Rating by it's id.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductRatings>> GetProductRating(int id)
        {
            var cartProduct = await _context.ProductRatings.FindAsync(id);

            if (cartProduct == null)
            {
                return NotFound();
            }
            return cartProduct;
        }

        /// <summary>
        /// Update a product rating.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductRating(int id, ProductRatings productRating)

        {
            if (id != productRating.Id)
            {
                return BadRequest();
            }
            _context.Entry(productRating).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartProductRatingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        /// <summary>
        /// Add a product rating.
        /// </summary>
        [HttpPost(Name = "AddProductRating")]
        public async Task<ActionResult<ProductRatings>> AddProductRating(ProductRatings productRating)
        {
            _context.ProductRatings.Add(productRating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductRating", new { id = productRating.Id }, productRating);
        }

        /// <summary>
        /// Delete a product rating.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductRating(int id)
        {
            var cartProduct = await _context.ProductRatings.FindAsync(id);
            if (cartProduct == null)
            {
                return NotFound();
            }
            _context.ProductRatings.Remove(cartProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Check if a product rating exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if the product exists, false if it doesn't.</returns>
        private bool CartProductRatingExists(int id)
        {
            return _context.ProductRatings.Any(e => e.Id == id);
        }
    }
}
