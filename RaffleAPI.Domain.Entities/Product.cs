namespace RaffleAPI.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
