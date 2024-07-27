using System.ComponentModel.DataAnnotations;

namespace RaffleAPI.Domain.Entities
{
    public class RaffleNumber
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Number { get; set; }
    }
}
