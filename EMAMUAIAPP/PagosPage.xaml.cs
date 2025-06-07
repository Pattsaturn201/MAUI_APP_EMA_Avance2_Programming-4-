using System.Collections.ObjectModel;

namespace EMAMUAIAPP
{
    public partial class PagosPage : ContentPage
    {
        public ObservableCollection<Pago> Pagos { get; set; }

        public PagosPage()
        {
            InitializeComponent();

            Pagos = new ObservableCollection<Pago>
            {
                new Pago { Cliente = "Juan Pérez", Monto = "$150.00", Fecha = "06/06/2025" },
                new Pago { Cliente = "Ana Gómez", Monto = "$200.00", Fecha = "05/06/2025" }
            };

            PagosCollectionView.ItemsSource = Pagos;
        }

        private async void OnAgregarPagoClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Registrar Pago", "Aquí se abriría un formulario para registrar un nuevo pago.", "OK");
        }
    }

    public class Pago
    {
        public string Cliente { get; set; }
        public string Monto { get; set; }
        public string Fecha { get; set; }
    }
}
