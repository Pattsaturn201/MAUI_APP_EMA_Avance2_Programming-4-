using System.Net.Http.Json;
using EMAMUAIAPP.Models;

public class EmpleadosService
{
    private readonly HttpClient _httpClient;

    public EmpleadosService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Empleados>> ObtenerTodosAsync()
        => await _httpClient.GetFromJsonAsync<List<Empleados>>("Empleados");

    public async Task<Empleados?> ObtenerPorIdAsync(int id)
        => await _httpClient.GetFromJsonAsync<Empleados>($"Empleados/{id}");

    public async Task<Empleados?> CrearAsync(Empleados empleado)
    {
        var response = await _httpClient.PostAsJsonAsync("Empleados", empleado);
        return await response.Content.ReadFromJsonAsync<Empleados>();
    }

    public async Task<bool> ActualizarAsync(Empleados empleado)
    {
        var response = await _httpClient.PutAsJsonAsync($"Empleados/{empleado.Id}", empleado);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"Empleados/{id}");
        return response.IsSuccessStatusCode;
    }
}
