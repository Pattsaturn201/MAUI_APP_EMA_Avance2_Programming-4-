using EMAMUAIAPP.Models;
using EMAMUAIAPP.Services;

namespace EMAMUAIAPP;

public partial class EquipoFormularioPage : ContentPage, IQueryAttributable
{
    private EquiposServices _equiposService = new();
    private Equipo _equipoExistente;

    public EquipoFormularioPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("equipo"))
        {
            _equipoExistente = query["equipo"] as Equipo;
            Title = "Editar Equipo";

            NombreEntry.Text = _equipoExistente.Nombre;
            MarcaEntry.Text = _equipoExistente.Marca;
            ModeloEntry.Text = _equipoExistente.Modelo;
            SerialEntry.Text = _equipoExistente.Serial;
            FechaAdquisicionPicker.Date = _equipoExistente.FechaAdquisicion;
            FechaBajaPicker.Date = _equipoExistente.FechaBaja ?? DateTime.Today;
        }
        else
        {
            Title = "Agregar Equipo";
            FechaAdquisicionPicker.Date = DateTime.Today;
            FechaBajaPicker.Date = DateTime.Today;
        }
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NombreEntry.Text) ||
            string.IsNullOrWhiteSpace(MarcaEntry.Text) ||
            string.IsNullOrWhiteSpace(ModeloEntry.Text) ||
            string.IsNullOrWhiteSpace(SerialEntry.Text))
        {
            await DisplayAlert("Error", "Por favor completa todos los campos obligatorios.", "OK");
            return;
        }

        var equipo = new Equipo
        {
            Id = _equipoExistente?.Id ?? 0,
            Nombre = NombreEntry.Text,
            Marca = MarcaEntry.Text,
            Modelo = ModeloEntry.Text,
            Serial = SerialEntry.Text,
            FechaAdquisicion = FechaAdquisicionPicker.Date,
            FechaBaja = FechaBajaPicker.Date
        };

        if (_equipoExistente == null)
            await _equiposService.CrearEquipoAsync(equipo);
        else
            await _equiposService.ActualizarEquipoAsync(equipo.Id, equipo);

        await Shell.Current.GoToAsync("//EquiposPage");
        // Regresa a la página  (EquiposPage)
    }
}
