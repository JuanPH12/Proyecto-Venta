using CsvHelper;
using System.Globalization;
using Proyecto_Venta.Interfaces;
using Proyecto_Venta.Models;

namespace Proyecto_Venta.Data
{
    public class CsvExtractor : IExtractor
    {
        private readonly ILogger<CsvExtractor> _logger;

        public CsvExtractor(ILogger<CsvExtractor> logger)
        {
            _logger = logger;
        }

        public async Task ExtractAsync()
        {
            _logger.LogInformation("Leyendo CSV...");

            using var reader = new StreamReader("Customer.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<Venta>().ToList();

            foreach (var venta in records)
            {
                _logger.LogInformation($"CSV -> {venta.Producto} - {venta.Precio}");
            }

            await Task.CompletedTask;
        }
    }
}