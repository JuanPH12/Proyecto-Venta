using Proyecto_Venta.Interfaces;

namespace Proyecto_Venta.Api
{
    public class ApiExtractor : IExtractor
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ApiExtractor> _logger;

        public ApiExtractor(HttpClient httpClient, ILogger<ApiExtractor> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task ExtractAsync()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

            var data = await response.Content.ReadAsStringAsync();

            _logger.LogInformation("Datos obtenidos desde API");
        }
    }
}