using System.Net.Http.Json;
using EMAMUAIAPP.Models;

public class PagosServices
{
    private readonly HttpClient _httpClient;

    public PagosServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Pagos>> ObtenerTodosAsync()
        => await _httpClient.GetFromJsonAsync<List<Pagos>>("Pagos");

    public async Task<Pagos?> ObtenerPorIdAsync(int id)
        => await _httpClient.GetFromJsonAsync<Pagos>($"Pagos/{id}");

    public async Task<Pagos?> CrearAsync(Pagos pago)
    {
        var response = await _httpClient.PostAsJsonAsync("Pagos", pago);
        return await response.Content.ReadFromJsonAsync<Pagos>();
    }

    public async Task<bool> ActualizarAsync(Pagos pago)
    {
        var response = await _httpClient.PutAsJsonAsync($"Pagos/{pago.Id}", pago);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"Pagos/{id}");
        return response.IsSuccessStatusCode;
    }
}
