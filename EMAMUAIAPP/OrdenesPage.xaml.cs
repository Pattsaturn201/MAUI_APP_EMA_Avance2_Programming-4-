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

        await Shell.Current.GoToAsync(nameof(OrdenFormularioPage));

    }
}
