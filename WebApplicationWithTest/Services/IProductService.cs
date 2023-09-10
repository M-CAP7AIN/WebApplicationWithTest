using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationWithTest.Models;

namespace WebApplicationWithTest.Services
{
    public interface IProductService
    {
        Task<List<Product>> getProductsAsync();
        Task<Product> getProductAsync(int id);
        Task<int> addProductAsync(Product product);
    }
}
