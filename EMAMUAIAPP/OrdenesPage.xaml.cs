using EMAMUAIAPP.Models;
using EMAMUAIAPP.Services;
using System.Collections.ObjectModel;

namespace EMAMUAIAPP;

public partial class OrdenesPage : ContentPage
{
    public ObservableCollection<OrdenTrabajo> Ordenes { get; set; } = new();
    private OrdenTrabajoService _ordenService = new();

    public OrdenesPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CargarOrdenes();
    }

    private async Task CargarOrdenes()
    {
        var ordenes = await _ordenService.ObtenerOrdenesAsync();

        Ordenes.Clear();
        foreach (var orden in ordenes)
            Ordenes.Add(orden);

        OrdenesCollectionView.ItemsSource = Ordenes;
    }

    private async void OnAgregarOrdenClicked(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("///OrdenFormularioPage");

    }
    private async void OnEditarOrdenClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var orden = button?.CommandParameter as OrdenTrabajo;

        if (orden != null)
        {
            await Shell.Current.GoToAsync("///OrdenFormularioPage", true, new Dictionary<string, object>
        {
            { "OrdenSeleccionada", orden }
        });
        }
    }

    private async void OnEliminarOrdenClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var orden = button?.CommandParameter as OrdenTrabajo;

        if (orden != null)
        {
            var confirm = await DisplayAlert("Confirmar", $"¿Eliminar la orden de {orden.NombreEquipo}?", "Sí", "No");
            if (confirm)
            {
                await _ordenService.EliminarOrdenAsync(orden.Id);
                await CargarOrdenes();
            }
        }
    }

}
