using EMAMUAIAPP.Services;
using EMAMUAIAPP.Models;

namespace EMAMUAIAPP
{
    public partial class PagosPage : ContentPage
    {
        private readonly PagosServices _pagosService;

        public PagosPage(PagosServices pagosService)
        {
            InitializeComponent();
            _pagosService = pagosService;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var pagos = await _pagosService.ObtenerTodosAsync();
            // Usa la lista de pagos en la UI
        }
    }
}
