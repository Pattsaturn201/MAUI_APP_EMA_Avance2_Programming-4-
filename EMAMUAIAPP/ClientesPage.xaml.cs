using System.Collections.ObjectModel;

namespace EMAMUAIAPP
{
    public partial class ClientesPage : ContentPage
    {
        public ObservableCollection<Cliente> Clientes { get; set; }

        public ClientesPage()
        {
            InitializeComponent();

            Clientes = new ObservableCollection<Cliente>
            {
                new Cliente { Nombre = "Andrés Castillo", Telefono = "123456789" },
                new Cliente { Nombre = "María Torres", Telefono = "987654321" }
            };

            ClientesCollectionView.ItemsSource = Clientes;
        }

        private async void OnAgregarClienteClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Nuevo Cliente", "Aquí se abriría un formulario para agregar clientes.", "OK");
        }
    }

    public class Cliente
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
    }
}
