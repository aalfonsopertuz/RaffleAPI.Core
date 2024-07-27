using RaffleAPI.Application.DTOs.Requests;
using RaffleAPI.Application.Interfaces.Services;
using RaffleAPI.Domain.Entities;
using RaffleAPI.Domain.Repositories.Repositories;

namespace RaffleAPI.Application.Services.Services
{
    public class RaffleService : IRaffleService
    {
        private readonly IRaffleRepository _raffleRepository;

        public RaffleService(IRaffleRepository raffleRepository)
        {
            _raffleRepository = raffleRepository;
        }

        public async Task<string> AssignNumber(AssignNumberRequest assignNumberRequest)
        {
            int nextNumber = await _raffleRepository.GetNextAvailableNumber(assignNumberRequest.ClientId);

            do
            {
                nextNumber = nextNumber + 1;
            }
            while (!IsNumberValid(nextNumber));

            var raffleNumber = new RaffleNumber
            {
                ClientId = assignNumberRequest.ClientId,
                UserId = assignNumberRequest.UserId,
                ProductId = assignNumberRequest.ProductId,
                Number = nextNumber
            };

            _raffleRepository.Add(raffleNumber);
            await _raffleRepository.SaveChangesAsync();

            return nextNumber.ToString("D5");
        }

        private static bool IsNumberValid(int number)
        {
            string numStr = number.ToString("D5");
            for (int i = 0; i < numStr.Length - 2; i++)
            {
                if (numStr[i] == numStr[i + 1] && numStr[i + 1] == numStr[i + 2])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
