using RaffleAPI.Application.DTOs.Requests;

namespace RaffleAPI.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<int> CreateProduct(CreateProductRequest createProductRequest);
    }
}
