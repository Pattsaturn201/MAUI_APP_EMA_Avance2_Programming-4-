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
            await DisplayAlert("Agregar Cliente", "Aquí se mostraría un formulario para agregar un nuevo cliente.", "OK");
        }

        private async void OnEditarClienteClicked(object sender, EventArgs e)
        {
            var cliente = (sender as Button)?.BindingContext as Clientes;
            if (cliente != null)
            {
                await DisplayAlert("Editar Cliente", $"Editar datos de {cliente.NombreCompleto}", "OK");
                // Aquí puedes abrir una nueva página para editar los datos
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
