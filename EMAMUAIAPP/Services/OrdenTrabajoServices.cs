using System.Net.Http.Json;
using EMAMUAIAPP.Models;

public class OrdenTrabajoServices
{
    private readonly HttpClient _httpClient;

    public OrdenTrabajoServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<OrdenTrabajo>> ObtenerTodasAsync()
        => await _httpClient.GetFromJsonAsync<List<OrdenTrabajo>>("OrdenTrabajo");

    public async Task<OrdenTrabajo?> ObtenerPorIdAsync(int id)
        => await _httpClient.GetFromJsonAsync<OrdenTrabajo>($"OrdenTrabajo/{id}");

    public async Task<OrdenTrabajo?> CrearAsync(OrdenTrabajo orden)
    {
        var response = await _httpClient.PostAsJsonAsync("OrdenTrabajo", orden);
        return await response.Content.ReadFromJsonAsync<OrdenTrabajo>();
    }

    public async Task<bool> ActualizarAsync(OrdenTrabajo orden)
    {
        var response = await _httpClient.PutAsJsonAsync($"OrdenTrabajo/{orden.Id}", orden);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"OrdenTrabajo/{id}");
        return response.IsSuccessStatusCode;
    }
}
