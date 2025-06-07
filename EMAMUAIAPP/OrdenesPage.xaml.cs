using System.Collections.ObjectModel;

namespace EMAMUAIAPP
{
    public partial class OrdenesPage : ContentPage
    {
        public ObservableCollection<Orden> Ordenes { get; set; }

        public OrdenesPage()
        {
            InitializeComponent();

            Ordenes = new ObservableCollection<Orden>
            {
                new Orden { Titulo = "Revisión Ascensor A1", Descripcion = "Cambio de poleas", Fecha = "07/06/2025" },
                new Orden { Titulo = "Instalación Panel B", Descripcion = "Configurar sistema", Fecha = "06/06/2025" }
            };

            OrdenesCollectionView.ItemsSource = Ordenes;
        }

        private async void OnAgregarOrdenClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Agregar Orden", "Aquí se abriría un formulario para agregar una orden.", "OK");
        }
    }

    public class Orden
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
    }
}

