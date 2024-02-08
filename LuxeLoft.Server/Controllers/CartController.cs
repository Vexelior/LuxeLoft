using LuxeLoft.Server.Data.Context;
using LuxeLoft.Server.Data.Models.Carts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LuxeLoft.Server.Controllers
{
    /// <summary>
    /// The controller for the carts in the database.
    /// </summary>
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all carts from the database.
        /// </summary>
        /// <returns>Returns all carts from the database.</returns>
        [HttpGet(Name = "GetCarts")]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            return await _context.Carts.ToListAsync();
        }

        /// <summary>
        /// Gets a cart by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a cart by its id.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
            var cart = await _context.Carts.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        /// <summary>
        /// Updates a cart by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cart"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, Cart cart)
        {
            if (id != cart.Id)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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
        /// Adds a cart to the database.
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPost(Name = "AddCart")]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { id = cart.Id }, cart);
        }

        /// <summary>
        /// Deletes a cart by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var cart = await _context.Carts.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Checks if a cart exists by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns true if the cart exists, otherwise false.</returns>
        private bool CartExists(int id)
        {
            return _context.Carts.Any(e => e.Id == id);
        }
    }
}
