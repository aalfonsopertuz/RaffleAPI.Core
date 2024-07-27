using RaffleAPI.Application.DTOs.Requests;
using RaffleAPI.Application.Interfaces.Services;
using RaffleAPI.Domain.Entities;
using RaffleAPI.Domain.Repositories.Repositories;

namespace RaffleAPI.Application.Services.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<int> CreateProduct(CreateProductRequest createProductRequest)
        {
            var product = new Product
            {
                ClientId = createProductRequest.ClientId,
                Name = createProductRequest.ProductName,
                Description = createProductRequest.ProductDescription
            };

            return await _productRepository.Add(product);
        }
    }
}
