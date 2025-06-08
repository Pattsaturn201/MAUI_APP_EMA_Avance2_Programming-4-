using System.Net.Http;
using System.Text;
using System.Text.Json;
using EMAMUAIAPP.Models;

namespace EMAMUAIAPP.Services
{
    public class ClientesServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7153/api";

        public ClientesServices()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Clientes>> ObtenerClientesAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/Clientes");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Clientes>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task CrearClienteAsync(Clientes cliente)
        {
            var json = JsonSerializer.Serialize(cliente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_baseUrl}/Clientes", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task ActualizarClienteAsync(int id, Clientes cliente)
        {
            var json = JsonSerializer.Serialize(cliente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_baseUrl}/Clientes/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task EliminarClienteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/Clientes/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
