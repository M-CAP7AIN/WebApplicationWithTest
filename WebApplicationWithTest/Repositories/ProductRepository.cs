using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationWithTest.Data;
using WebApplicationWithTest.Models;

namespace WebApplicationWithTest.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<int> AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Product> getProductAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<List<Product>> getProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }
    }
}
