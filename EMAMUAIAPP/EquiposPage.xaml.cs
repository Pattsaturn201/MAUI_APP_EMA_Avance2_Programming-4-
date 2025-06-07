using System.Collections.ObjectModel;

namespace EMAMUAIAPP
{
    public partial class EquiposPage : ContentPage
    {
        public ObservableCollection<Equipo> Equipos { get; set; }

        public EquiposPage()
        {
            InitializeComponent();

            Equipos = new ObservableCollection<Equipo>
            {
                new Equipo { Codigo = "EQ-001", Estado = "Operativo" },
                new Equipo { Codigo = "EQ-002", Estado = "En reparaci�n" }
            };

            EquiposCollectionView.ItemsSource = Equipos;
        }

        private async void OnAgregarEquipoClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Nuevo Equipo", "Aqu� se abrir�a un formulario para registrar equipos.", "OK");
        }
    }

    public class Equipo
    {
        public string Codigo { get; set; }
        public string Estado { get; set; }
    }
}
