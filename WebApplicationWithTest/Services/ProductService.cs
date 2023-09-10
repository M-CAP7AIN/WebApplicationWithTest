using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationWithTest.Models;
using WebApplicationWithTest.Repositories;

namespace WebApplicationWithTest.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<int> addProductAsync(Product product)
        {
            return await _productRepository.AddAsync(product);
        }

        public async Task<List<Product>> getProductsAsync()
        {
            return await _productRepository.getProductsAsync();
        }

        public async Task<Product> getProductAsync(int id)
        {
            return await _productRepository.getProductAsync(id);
        }
    }
}
