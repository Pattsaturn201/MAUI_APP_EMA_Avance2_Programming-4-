using System.Collections.ObjectModel;
using EMAMUAIAPP.Models;
using EMAMUAIAPP.Services;

namespace EMAMUAIAPP
{
    public partial class ClientesPage : ContentPage
    {
        public ObservableCollection<Clientes> Clientes { get; set; } = new();
        private ClientesServices _clientesService = new();

        public ClientesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargarClientes(); 
        }

        private async void CargarClientes()
        {
            var clientes = await _clientesService.ObtenerClientesAsync();
            Clientes.Clear();

            foreach (var cliente in clientes)
                Clientes.Add(cliente);

            ClientesCollectionView.ItemsSource = Clientes;
        }

        private async void OnAgregarClienteClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(ClienteFormularioPage));
        }

        private async void OnEditarClienteClicked(object sender, EventArgs e)
        {
            var cliente = (sender as Button)?.BindingContext as Clientes;
            if (cliente != null)
            {
                var navigationParams = new Dictionary<string, object>
        {
            { "cliente", cliente }
        };

                await Shell.Current.GoToAsync($"{nameof(ClienteFormularioPage)}", navigationParams);
            }
        }



        private async void OnEliminarClienteClicked(object sender, EventArgs e)
        {
            var cliente = (sender as Button)?.BindingContext as Clientes;
            if (cliente != null)
            {
                bool confirmado = await DisplayAlert("Eliminar", $"¿Deseas eliminar a {cliente.NombreCompleto}?", "Sí", "No");
                if (confirmado)
                {
                    Clientes.Remove(cliente);
                    await _clientesService.EliminarClienteAsync(cliente.Id);
                }
            }
        }
    }
}
