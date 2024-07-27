using Microsoft.EntityFrameworkCore;
using RaffleAPI.Domain.Entities;
using RaffleAPI.Domain.Repositories.Repositories;
using RaffleAPI.Infrastructure.Data.Context;

namespace RaffleAPI.Infrastructure.Repositories.Repositories
{
    public class RaffleRepository(ApplicationDbContext context) : IRaffleRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<int> GetNextAvailableNumber(int clientId)
        {
            var maxNumber = await _context.RaffleNumbers
                .Where(r => r.ClientId == clientId)
                .MaxAsync(r => (int?)r.Number) ?? 0;
            return maxNumber + 1;
        }

        public void Add(RaffleNumber raffleNumber)
        {
            _context.RaffleNumbers.Add(raffleNumber);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
