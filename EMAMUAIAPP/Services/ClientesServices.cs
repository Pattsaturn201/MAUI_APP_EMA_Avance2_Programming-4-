using EMAMUAIAPP.Models;
using System.Net.Http.Json;

namespace EMAMUAIAPP.Services
{
    public class ClientesServices
    {
        private readonly HttpClient _httpClient;

        public ClientesServices()
        {
            // Cambia esta URL si tu API usa un puerto diferente
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7153") // <-- Ajusta si tu API corre en otro puerto
            };
        }

        // Obtener todos los clientes
        public async Task<List<Clientes>> ObtenerClientesAsync()
        {
            var response = await _httpClient.GetAsync("/api/clientes");

            if (response.IsSuccessStatusCode)
            {
                var clientes = await response.Content.ReadFromJsonAsync<List<Clientes>>();
                return clientes ?? new List<Clientes>();
            }

            return new List<Clientes>();
        }

        // Crear un nuevo cliente
        public async Task<bool> CrearClienteAsync(Clientes nuevoCliente)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/clientes", nuevoCliente);
            return response.IsSuccessStatusCode;
        }

        // Actualizar cliente
        public async Task<bool> ActualizarClienteAsync(int id, Clientes cliente)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/clientes/{id}", cliente);
            return response.IsSuccessStatusCode;
        }

        // Eliminar cliente
        public async Task<bool> EliminarClienteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/clientes/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
