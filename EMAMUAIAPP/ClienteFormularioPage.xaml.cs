using EMAMUAIAPP.Models;
using EMAMUAIAPP.Services;

namespace EMAMUAIAPP;

public partial class ClienteFormularioPage : ContentPage, IQueryAttributable
{
    private ClientesServices _clientesService = new();
    private Clientes _clienteExistente;

    public ClienteFormularioPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("cliente"))
        {
            _clienteExistente = query["cliente"] as Clientes;
            Title = "Editar Cliente";

            NombreCompletoEntry.Text = _clienteExistente.NombreCompleto;
            ApellidoCompletoEntry.Text = _clienteExistente.ApellidoCompleto;
            CorreoEntry.Text = _clienteExistente.Correo;
            TelefonoEntry.Text = _clienteExistente.Telefono;
            DireccionEntry.Text = _clienteExistente.Direccion;
            MetodosPagoEntry.Text = string.Join(", ", _clienteExistente.MetodosDePago);
        }
        else
        {
            Title = "Agregar Cliente";
        }
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        var cliente = new Clientes
        {
            Id = _clienteExistente?.Id ?? 0,
            NombreCompleto = NombreCompletoEntry.Text,
            ApellidoCompleto = ApellidoCompletoEntry.Text,
            Correo = CorreoEntry.Text,
            Telefono = TelefonoEntry.Text,
            Direccion = DireccionEntry.Text,
            MetodosDePago = MetodosPagoEntry.Text.Split(',').Select(p => p.Trim()).ToList()
        };

        if (_clienteExistente == null)
            await _clientesService.CrearClienteAsync(cliente);
        else
            await _clientesService.ActualizarClienteAsync(cliente.Id, cliente);

        await Shell.Current.GoToAsync("ClientesPage");
    }
}
