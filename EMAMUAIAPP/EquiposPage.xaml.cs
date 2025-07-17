using System.Collections.ObjectModel;
using EMAMUAIAPP.Models;
using EMAMUAIAPP.Services;

namespace EMAMUAIAPP
{
    public partial class EquiposPage : ContentPage
    {
        public ObservableCollection<Equipo> Equipos { get; set; } = new();
        private EquiposServices _equiposService = new();

        public EquiposPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargarEquipos();
        }

        private async void CargarEquipos()
        {
            var equipos = await _equiposService.ObtenerEquiposAsync();
            Equipos.Clear();

            foreach (var equipo in equipos)
                Equipos.Add(equipo);

            EquiposCollectionView.ItemsSource = Equipos;
        }

        private async void OnAgregarEquipoClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(EquipoFormularioPage));
        }

        private async void OnEditarEquipoClicked(object sender, EventArgs e)
        {
            var equipo = (sender as Button)?.BindingContext as Equipo;
            if (equipo != null)
            {
                var navigationParams = new Dictionary<string, object>
                {
                    { "equipo", equipo }
                };

                await Shell.Current.GoToAsync($"{nameof(EquipoFormularioPage)}", navigationParams);
            }
        }

        private async void OnEliminarEquipoClicked(object sender, EventArgs e)
        {
            var equipo = (sender as Button)?.BindingContext as Equipo;
            if (equipo != null)
            {
                bool confirmado = await DisplayAlert("Eliminar", $"¿Deseas eliminar el equipo {equipo.Nombre}?", "Sí", "No");
                if (confirmado)
                {
                    Equipos.Remove(equipo);
                    await _equiposService.EliminarEquipoAsync(equipo.Id);
                }
            }
        }

        private async void OnBusquedaTextChanged(object sender, TextChangedEventArgs e)
        {
            string termino = e.NewTextValue;

            if (string.IsNullOrWhiteSpace(termino))
            {
                CargarEquipos();
            }
            else
            {
                try
                {
                    var resultados = await _equiposService.BuscarEquiposAsync(termino);
                    Equipos.Clear();
                    foreach (var equipo in resultados)
                        Equipos.Add(equipo);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"No se pudo buscar equipos: {ex.Message}", "OK");
                }
            }
        }

    }
}
