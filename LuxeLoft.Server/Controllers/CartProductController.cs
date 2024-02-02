using LuxeLoft.Server.Data.Context;
using LuxeLoft.Server.Data.Models.Carts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LuxeLoft.Server.Controllers
{
    /// <summary>
    /// The controller for the products in carts.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all the products in the carts.
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetCartProducts")]
        public async Task<ActionResult<IEnumerable<CartProducts>>> GetCartProducts()
        {
            return await _context.CartProducts.ToListAsync();
        }

        /// <summary>
        /// Get a product in a cart by its id.
        /// </summary>
        /// <returns>Cart by it's id.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CartProducts>> GetCartProduct(int id)
        {
            var cartProduct = await _context.CartProducts.FindAsync(id);

            if (cartProduct == null)
            {
                return NotFound();
            }
            return cartProduct;
        }

        /// <summary>
        /// Update a product in a cart.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartProduct(int id, CartProducts cartProduct)
        {
            if (id != cartProduct.Id)
            {
                return BadRequest();
            }
            _context.Entry(cartProduct).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartProductExists(id))
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
        /// Add a product to a cart.
        /// </summary>
        [HttpPost(Name = "AddProductToCart")]
        public async Task<ActionResult<CartProducts>> AddProductToCart(CartProducts cartProduct)
        {
            _context.CartProducts.Add(cartProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartProduct", new { id = cartProduct.Id }, cartProduct);
        }

        /// <summary>
        /// Delete a product from a cart.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartProduct(int id)
        {
            var cartProduct = await _context.CartProducts.FindAsync(id);
            if (cartProduct == null)
            {
                return NotFound();
            }
            _context.CartProducts.Remove(cartProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Check if a product in a cart exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if the product exists, false if it doesn't.</returns>
        private bool CartProductExists(int id)
        {
            return _context.CartProducts.Any(e => e.Id == id);
        }
    }
}
