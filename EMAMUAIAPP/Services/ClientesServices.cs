using System.Net.Http.Json;
using EMAMUAIAPP.Models;


public class ClientesService
{
    private readonly HttpClient _httpClient;

    public ClientesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Clientes>> ObtenerTodosAsync()
        => await _httpClient.GetFromJsonAsync<List<Clientes>>("Clientes");

    public async Task<Clientes?> ObtenerPorIdAsync(int id)
        => await _httpClient.GetFromJsonAsync<Clientes>($"Clientes/{id}");

    public async Task<Clientes?> CrearAsync(Clientes cliente)
    {
        var response = await _httpClient.PostAsJsonAsync("Clientes", cliente);
        return await response.Content.ReadFromJsonAsync<Clientes>(); // Fixed typo: 'Cliente' to 'Clientes'  
    }

    public async Task<bool> ActualizarAsync(Clientes cliente) // Fixed typo: 'Cliente' to 'Clientes'  
    {
        var response = await _httpClient.PutAsJsonAsync($"Clientes/{cliente.Id}", cliente);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"Clientes/{id}");
        return response.IsSuccessStatusCode;
    }
}

