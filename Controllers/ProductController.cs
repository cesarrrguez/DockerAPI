using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DockerApi.Data;
using DockerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return Ok(await _context.Products.ToListAsync().ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _context.Products.AddAsync(product).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update(int id, [FromBody] Product productInput)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _context.Products.FindAsync(id).ConfigureAwait(false);

            if (product == null) return NotFound();

            product.Name = productInput.Name;
            product.Price = productInput.Price;
            product.Description = productInput.Description;

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id).ConfigureAwait(false);

            if (product == null) return NotFound();

            _context.Remove(product);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return Ok(product);
        }
    }
}
