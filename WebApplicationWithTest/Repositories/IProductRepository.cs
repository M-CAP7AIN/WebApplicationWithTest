using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationWithTest.Models;

namespace WebApplicationWithTest.Repositories
{
    public interface IProductRepository
    {
        Task<int> AddAsync(Product product);
        Task<List<Product>> getProductsAsync();
        Task<Product> getProductAsync(int id);
    }
}
