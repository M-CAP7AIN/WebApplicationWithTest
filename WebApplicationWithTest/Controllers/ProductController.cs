using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationWithTest.Data;
using WebApplicationWithTest.Models;
using WebApplicationWithTest.Services;

namespace WebApplicationWithTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return await _productService.getProductsAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productService.getProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }


        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var result = await _productService.addProductAsync(product);



            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }
    }
}
