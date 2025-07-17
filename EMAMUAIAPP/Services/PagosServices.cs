using System.Net.Http;
using System.Text;
using System.Text.Json;
using EMAMUAIAPP.Models;

namespace EMAMUAIAPP.Services
{
    public class PagosServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7153/api";

        public PagosServices()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Pagos>> ObtenerPagosAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/Pagos");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Pagos>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task CrearPagoAsync(Pagos pago)
        {
            var json = JsonSerializer.Serialize(pago);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_baseUrl}/Pagos", content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error del servidor: {response.StatusCode} - {error}");
            }
        }


        public async Task ActualizarPagoAsync(int id, Pagos pago)
        {
            var json = JsonSerializer.Serialize(pago);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_baseUrl}/Pagos/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task EliminarPagoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/Pagos/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
