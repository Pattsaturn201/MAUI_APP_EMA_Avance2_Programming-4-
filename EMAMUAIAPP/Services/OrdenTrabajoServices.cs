using EMAMUAIAPP.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace EMAMUAIAPP.Services
{
    public class OrdenTrabajoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7153/api";

        public OrdenTrabajoService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<OrdenTrabajo>> ObtenerOrdenesAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/OrdenTrabajo");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<OrdenTrabajo>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task CrearOrdenAsync(OrdenTrabajo orden)
        {
            var json = JsonSerializer.Serialize(orden);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_baseUrl}/OrdenTrabajo", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task ActualizarOrdenAsync(int id, OrdenTrabajo orden)
        {
            var json = JsonSerializer.Serialize(orden);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_baseUrl}/OrdenTrabajo/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task EliminarOrdenAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/OrdenTrabajo/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
