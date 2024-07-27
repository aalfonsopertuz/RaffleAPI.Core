using RaffleAPI.Domain.Entities;

namespace RaffleAPI.Domain.Repositories.Repositories
{
    public interface IProductRepository
    {
        Task<int> Add(Product product);
    }
}
