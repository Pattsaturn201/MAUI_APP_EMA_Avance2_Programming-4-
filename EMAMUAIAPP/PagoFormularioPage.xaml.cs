using EMAMUAIAPP.Models;
using EMAMUAIAPP.Services;

namespace EMAMUAIAPP;

public partial class PagoFormularioPage : ContentPage
{
    private readonly PagosServices _pagosService = new();

    public PagoFormularioPage()
    {
        InitializeComponent();
        FechaPagoPicker.Date = DateTime.Today;
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        try
        {
            // Validaciones
            if (!int.TryParse(VentaIdEntry.Text, out int ventaId))
            {
                await DisplayAlert("Error", "VentaId inválido.", "OK");
                return;
            }

            if (!decimal.TryParse(MontoEntry.Text, out decimal monto))
            {
                await DisplayAlert("Error", "Monto inválido.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(EntidadExternaEntry.Text) || string.IsNullOrWhiteSpace(MetodoPagoEntry.Text))
            {
                await DisplayAlert("Error", "Entidad externa y método de pago son obligatorios.", "OK");
                return;
            }

            // Crear objeto
            var nuevoPago = new Pagos
            {
                VentaId = ventaId,
                Monto = monto,
                FechaPago = FechaPagoPicker.Date,
                EntidadExterna = EntidadExternaEntry.Text,
                MetodoPago = MetodoPagoEntry.Text,
                DetallesCuenta = DetallesCuentaEntry.Text ?? ""
            };

            await _pagosService.CrearPagoAsync(nuevoPago);
            await DisplayAlert("Éxito", "Pago registrado correctamente", "OK");
            await Shell.Current.GoToAsync("///PagosPage");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un problema: {ex.Message}", "OK");
        }
    }
}
