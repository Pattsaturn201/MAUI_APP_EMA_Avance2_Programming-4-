using EMAMUAIAPP.Models;
using EMAMUAIAPP.Services;

namespace EMAMUAIAPP;
[QueryProperty(nameof(OrdenSeleccionada), "OrdenSeleccionada")]
public partial class OrdenFormularioPage : ContentPage
{
    private readonly OrdenTrabajoService _ordenService = new();
    private OrdenTrabajo ordenExistente;


    public OrdenTrabajo OrdenSeleccionada
    {
        get => ordenExistente;
        set
        {
            ordenExistente = value;
            if (ordenExistente != null)
                CargarDatosExistente();
        }
    }


    public OrdenFormularioPage()
    {
        InitializeComponent();
        FechaIngresoPicker.Date = DateTime.Today;
        FechaEntregaPicker.Date = DateTime.Today;
    }

    public OrdenFormularioPage(OrdenTrabajo orden) : this()
    {
        ordenExistente = orden;
        CargarDatosExistente();
    }

    private void CargarDatosExistente()
    {
        NombreEquipoEntry.Text = ordenExistente.NombreEquipo;
        CodigoEquipoEntry.Text = ordenExistente.CodigoEquipo;
        TipoMantenimientoEntry.Text = ordenExistente.TipoMantenimiento;
        FechaIngresoPicker.Date = ordenExistente.FechaIngreso;
        FechaEntregaPicker.Date = ordenExistente.FechaEntrega ?? DateTime.Today;
        DescripcionProblemaEditor.Text = ordenExistente.DescripcionProblema;
        ObservacionesEditor.Text = ordenExistente.Observaciones;
        EstadoPicker.SelectedItem = ordenExistente.Estado.ToString();
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NombreEquipoEntry.Text) ||
            string.IsNullOrWhiteSpace(CodigoEquipoEntry.Text) ||
            EstadoPicker.SelectedItem == null)
        {
            await DisplayAlert("Error", "Por favor completa los campos obligatorios.", "OK");
            return;
        }

        var nuevaOrden = new OrdenTrabajo
        {
            FechaIngreso = FechaIngresoPicker.Date,
            NombreEquipo = NombreEquipoEntry.Text,
            CodigoEquipo = CodigoEquipoEntry.Text,
            TipoMantenimiento = TipoMantenimientoEntry.Text,
            FechaEntrega = FechaEntregaPicker.Date,
            DescripcionProblema = DescripcionProblemaEditor.Text,
            Observaciones = ObservacionesEditor.Text,
            Estado = Enum.Parse<EstadoDeOrden>(EstadoPicker.SelectedItem.ToString())
        };

        try
        {
            if (ordenExistente == null)
            {
                await _ordenService.CrearOrdenAsync(nuevaOrden);
                await DisplayAlert("Éxito", "Orden creada correctamente.", "OK");
            }
            else
            {
                nuevaOrden.Id = ordenExistente.Id;
                await _ordenService.ActualizarOrdenAsync(nuevaOrden.Id, nuevaOrden);
                await DisplayAlert("Éxito", "Orden actualizada correctamente.", "OK");
            }

            await Shell.Current.GoToAsync("///OrdenesPage");
            
        }

        catch (HttpRequestException httpEx)
        {
            await DisplayAlert("Error HTTP", $"Error: {httpEx.Message}", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Excepción: {ex.Message}", "OK");
        }

    }
}

