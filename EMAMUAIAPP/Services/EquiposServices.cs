using System.Net.Http;
using System.Text;
using System.Text.Json;
using EMAMUAIAPP.Models;

namespace EMAMUAIAPP.Services
{
    public class EquiposServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7153/api";

        public EquiposServices()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Equipo>> ObtenerEquiposAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/Equipos");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Equipo>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task CrearEquipoAsync(Equipo equipo)
        {
            var json = JsonSerializer.Serialize(equipo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_baseUrl}/Equipos", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task ActualizarEquipoAsync(int id, Equipo equipo)
        {
            var json = JsonSerializer.Serialize(equipo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_baseUrl}/Equipos/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task EliminarEquipoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/Equipos/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
