using System.Net.Http.Json;
using EMAMUAIAPP.Models;

public class EquipoServices
{
    private readonly HttpClient _httpClient;

    public EquipoServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Equipo>> ObtenerTodosAsync()
        => await _httpClient.GetFromJsonAsync<List<Equipo>>("Equipo");

    public async Task<Equipo?> ObtenerPorIdAsync(int id)
        => await _httpClient.GetFromJsonAsync<Equipo>($"Equipo/{id}");

    public async Task<Equipo?> CrearAsync(Equipo equipo)
    {
        var response = await _httpClient.PostAsJsonAsync("Equipo", equipo);
        return await response.Content.ReadFromJsonAsync<Equipo>();
    }

    public async Task<bool> ActualizarAsync(Equipo equipo)
    {
        var response = await _httpClient.PutAsJsonAsync($"Equipo/{equipo.Id}", equipo);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"Equipo/{id}");
        return response.IsSuccessStatusCode;
    }
}
