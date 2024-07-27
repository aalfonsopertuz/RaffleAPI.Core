using RaffleAPI.Application.DTOs.Requests;

namespace RaffleAPI.Application.Interfaces.Services
{
    public interface IRaffleService
    {
        Task<string> AssignNumber(AssignNumberRequest assignNumberRequest);
    }
}
