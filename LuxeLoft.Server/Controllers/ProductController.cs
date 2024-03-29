﻿using LuxeLoft.Server.Data.Context;
using LuxeLoft.Server.Data.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LuxeLoft.Server.Controllers
{
    /// <summary>
    /// The controller for the products in the database.
    /// </summary>
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all products from the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        /// <summary>
        /// Gets a product by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        /// <summary>
        /// Updates a product by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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
        /// Adds a product to the database.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        /// <summary>
        /// Deletes a product by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Gets all men's products
        /// </summary>
        [HttpGet(Name = "GetMensClothing")]
        public async Task<IActionResult> GetMensClothing()
        {
            var products = await _context.Products.Where(p => p.Category == "men's clothing").ToListAsync();

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        /// <summary>
        /// Gets all Women's products
        /// </summary>
        [HttpGet(Name = "GetWomensClothing")]
        public async Task<IActionResult> GetWomensClothing()
        {
            var products = await _context.Products.Where(p => p.Category == "women's clothing").ToListAsync();

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        /// <summary>
        /// Gets all Jewelry products
        /// </summary>
        [HttpGet(Name = "GetJewelery")]
        public async Task<IActionResult> GetJewelery()
        {
            var products = await _context.Products.Where(p => p.Category == "jewelery").ToListAsync();

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        /// <summary>
        /// Gets all electronics/tech products
        /// </summary>
        [HttpGet(Name = "GetElectronics")]
        public async Task<IActionResult> GetElectronics()
        {
            var products = await _context.Products.Where(p => p.Category == "electronics").ToListAsync();

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        /// <summary>
        /// Gets all best selling products, randomly.
        /// </summary>
        /// <returns>A list of 10 products.</returns>
        [HttpGet(Name = "GetBestSellers")]
        public async Task<IActionResult> GetBestSellers()
        {
            var products = await _context.Products.OrderBy(p => Guid.NewGuid()).Take(10).ToListAsync();

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        /// <summary>
        /// Checks if a product exists by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
