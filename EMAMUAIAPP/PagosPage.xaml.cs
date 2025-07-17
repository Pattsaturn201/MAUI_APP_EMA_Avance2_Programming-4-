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


    private async void OnAgregarPagoClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///PagoFormularioPage");
    }
}
