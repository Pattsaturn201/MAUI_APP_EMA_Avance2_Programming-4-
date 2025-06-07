using System.Net.Http.Json;
using EMAMUAIAPP.Models;

public class EmpresaServices
{
    private readonly HttpClient _httpClient;

    public EmpresaServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Empresa>> ObtenerTodasAsync()
        => await _httpClient.GetFromJsonAsync<List<Empresa>>("Empresa");

    public async Task<Empresa?> ObtenerPorIdAsync(int id)
        => await _httpClient.GetFromJsonAsync<Empresa>($"Empresa/{id}");

    public async Task<Empresa?> CrearAsync(Empresa empresa)
    {
        var response = await _httpClient.PostAsJsonAsync("Empresa", empresa);
        return await response.Content.ReadFromJsonAsync<Empresa>();
    }

    public async Task<bool> ActualizarAsync(Empresa empresa)
    {
        var response = await _httpClient.PutAsJsonAsync($"Empresa/{empresa.Id}", empresa);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"Empresa/{id}");
        return response.IsSuccessStatusCode;
    }
}
