using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Services;


namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService service, ILogger<ProductController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            _logger.LogInformation("Fetching all products");
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            _logger.LogInformation("Fetching product with ID {Id}", id);
            var product = await _service.GetByIdAsync(id);
            if (product == null)
            {
                _logger.LogWarning("Product with ID {Id} not found", id);
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            _logger.LogInformation("Creating new product: {Name}", product.Name);
            var created = await _service.AddAsync(product);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(int id, Product product)
        {
            _logger.LogInformation("Updating product with ID {Id}", id);
            var updated = await _service.UpdateAsync(id, product);
            if (updated == null)
            {
                _logger.LogWarning("Failed to update. Product with ID {Id} not found", id);
                return NotFound();
            }
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Deleting product with ID {Id}", id);
            var result = await _service.DeleteAsync(id);
            if (!result)
            {
                _logger.LogWarning("Failed to delete. Product with ID {Id} not found", id);
                return NotFound();
            }
            return NoContent();
        }        
    }
}