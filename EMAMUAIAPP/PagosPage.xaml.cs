using EMAMUAIAPP.Models;
using EMAMUAIAPP.Services;
using System.Collections.ObjectModel;

namespace EMAMUAIAPP;

public partial class PagosPage : ContentPage
{
    public ObservableCollection<Pagos> Pagos { get; set; } = new();
    private List<Pagos> TodosLosPagos = new();
    private PagosServices _pagoService = new();
    

    public PagosPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CargarPagos();
    }

    private async Task CargarPagos()
    {
        var pagos = await _pagoService.ObtenerPagosAsync();

        TodosLosPagos = pagos; 
        Pagos.Clear();

        foreach (var pago in pagos)
            Pagos.Add(pago);

        PagosCollectionView.ItemsSource = Pagos;
    }

    private void OnBusquedaPagosChanged(object sender, TextChangedEventArgs e)
    {
        var textoBusqueda = e.NewTextValue?.ToLower() ?? "";

        var filtrados = TodosLosPagos.Where(p =>
            p.EntidadExterna.ToLower().Contains(textoBusqueda) ||
            p.MetodoPago.ToLower().Contains(textoBusqueda) ||
            p.VentaId.ToString().Contains(textoBusqueda) ||
            p.DetallesCuenta.ToLower().Contains(textoBusqueda)
        ).ToList();

        Pagos.Clear();
        foreach (var pago in filtrados)
            Pagos.Add(pago);
    }

    private async void OnEditarPagoClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var pago = button?.CommandParameter as Pagos;

        if (pago != null)
        {
            // Pasar el pago como parámetro
            await Shell.Current.GoToAsync("///PagoFormularioPage", new Dictionary<string, object>
        {
            { "PagoSeleccionado", pago }
        });
        }
    }

    private async void OnEliminarPagoClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var pago = button?.CommandParameter as Pagos;

        if (pago != null)
        {
            bool confirmar = await DisplayAlert("Eliminar", $"¿Eliminar el pago #{pago.Id}?", "Sí", "No");
            if (confirmar)
            {
                try
                {
                    await _pagoService.EliminarPagoAsync(pago.Id);
                    await CargarPagos();
                    await DisplayAlert("Éxito", "Pago eliminado", "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }
    }



    private async void OnAgregarPagoClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///PagoFormularioPage");
    }

    private async void OnPagoSeleccionado(object sender, EventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is Pagos pago)
        {
            await Shell.Current.GoToAsync($"PagoFormularioPage?PagoSeleccionado={System.Text.Json.JsonSerializer.Serialize(pago)}");
        }
    }

}
