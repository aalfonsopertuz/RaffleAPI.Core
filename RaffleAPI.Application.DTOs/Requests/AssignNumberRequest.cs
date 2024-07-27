namespace RaffleAPI.Application.DTOs.Requests
{
    public class AssignNumberRequest
    {
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
