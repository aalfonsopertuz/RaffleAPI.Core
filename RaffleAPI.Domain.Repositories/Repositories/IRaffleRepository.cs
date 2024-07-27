using RaffleAPI.Domain.Entities;

namespace RaffleAPI.Domain.Repositories.Repositories
{
    public interface IRaffleRepository
    {
        Task<int> GetNextAvailableNumber(int clientId);
        void Add(RaffleNumber raffleNumber);
        Task SaveChangesAsync();
    }
}
