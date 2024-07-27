using Microsoft.Data.SqlClient;
using RaffleAPI.Domain.Entities;
using RaffleAPI.Domain.Repositories.Repositories;
using System.Data;

namespace RaffleAPI.Infrastructure.Repositories.Repositories
{
    public class ProductRepository(SqlConnection sqlConnection) : IProductRepository
    {
        private readonly SqlConnection _sqlConnection = sqlConnection;

        public async Task<int> Add(Product product)
        {
            _sqlConnection.Open();
            using var command = new SqlCommand("INSERT INTO Products (ClientId, Name, Description) OUTPUT INSERTED.Id VALUES (@ClientId, @Name, @Description)", _sqlConnection);
            command.Parameters.Add(new SqlParameter("@ClientId", SqlDbType.Int) { Value = product.ClientId });
            command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 255) { Value = product.Name });
            command.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar) { Value = (object)product.Description! ?? DBNull.Value });

            var productId = await command.ExecuteScalarAsync();
            return productId == null ? 0 : (int)productId;
        }

    }
}
