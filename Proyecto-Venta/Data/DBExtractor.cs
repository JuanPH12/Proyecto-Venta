using Microsoft.Data.SqlClient;
using Proyecto_Venta.Interfaces;
using Proyecto_Venta.Models;

namespace Proyecto_Venta.Data
{
    public class DatabaseExtractor : IExtractor
    {
        private readonly IConfiguration _config;
        private readonly ILogger<DatabaseExtractor> _logger;

        public DatabaseExtractor(IConfiguration config, ILogger<DatabaseExtractor> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task ExtractAsync()
        {
            try
            {
                var connectionString = _config.GetConnectionString("DefaultConnection");

                using var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();

                var query = @"SELECT CustomerId, FirstName, LastName, Email, Phone, CityId, CountryId 
                              FROM Customer";

                using var command = new SqlCommand(query, connection);
                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var customer = new Customer
                    {
                        CustomerId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Email = reader.GetString(3),
                        Phone = reader.GetString(4),
                        CityId = reader.GetInt32(5),
                        CountryId = reader.GetInt32(6)
                    };

                    _logger.LogInformation($"DB -> {customer.FirstName} {customer.LastName}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al extraer datos de la BD");
            }
        }
    }
}