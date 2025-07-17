using EMAMUAIAPP.Models;
using EMAMUAIAPP.Services;

namespace EMAMUAIAPP;

[QueryProperty(nameof(PagoSeleccionado), "PagoSeleccionado")]
public partial class PagoFormularioPage : ContentPage
{
    private readonly PagosServices _pagosService = new();
    public Pagos PagoSeleccionado { get; set; }
    private Pagos _pagoExistente;

    public PagoFormularioPage()
    {
        InitializeComponent();
        FechaPagoPicker.Date = DateTime.Today;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (PagoSeleccionado != null)
        {
            VentaIdEntry.Text = PagoSeleccionado.VentaId.ToString();
            MontoEntry.Text = PagoSeleccionado.Monto.ToString();
            FechaPagoPicker.Date = PagoSeleccionado.FechaPago;
            EntidadExternaEntry.Text = PagoSeleccionado.EntidadExterna;
            MetodoPagoEntry.Text = PagoSeleccionado.MetodoPago;
            DetallesCuentaEntry.Text = PagoSeleccionado.DetallesCuenta;
        }
    }


    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        if (!int.TryParse(VentaIdEntry.Text, out int ventaId) || ventaId <= 0)
        {
            await DisplayAlert("Error", "Venta ID inválido.", "OK");
            return;
        }

        if (!decimal.TryParse(MontoEntry.Text, out decimal monto) || monto <= 0)
        {
            await DisplayAlert("Error", "Monto inválido.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(EntidadExternaEntry.Text) || string.IsNullOrWhiteSpace(MetodoPagoEntry.Text))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
            return;
        }

        var nuevoPago = new Pagos
        {
            Id = PagoSeleccionado?.Id ?? 0,
            VentaId = ventaId,
            Monto = monto,
            FechaPago = FechaPagoPicker.Date,
            EntidadExterna = EntidadExternaEntry.Text.Trim(),
            MetodoPago = MetodoPagoEntry.Text.Trim(),
            DetallesCuenta = DetallesCuentaEntry.Text?.Trim() ?? string.Empty
        };

        try
        {
            if (nuevoPago.Id == 0)
            {
                // Crear
                await _pagosService.CrearPagoAsync(nuevoPago);
                await DisplayAlert("Éxito", "Pago creado correctamente.", "OK");
            }
            else
            {
                // Editar
                await _pagosService.ActualizarPagoAsync(nuevoPago.Id, nuevoPago);
                await DisplayAlert("Éxito", "Pago actualizado correctamente.", "OK");
            }

            await Shell.Current.GoToAsync("///PagosPage");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo guardar el pago.\n{ex.Message}", "OK");
        }
    }

    private async void OnCancelarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///PagosPage");
    }
}
