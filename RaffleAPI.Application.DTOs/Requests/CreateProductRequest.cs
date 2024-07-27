namespace RaffleAPI.Application.DTOs.Requests
{
    public class CreateProductRequest
    {
        public int ClientId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
    }
}
