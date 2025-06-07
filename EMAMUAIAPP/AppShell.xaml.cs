namespace EMAMUAIAPP
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registro de rutas para navegación con Shell
            Routing.RegisterRoute(nameof(PagosPage), typeof(PagosPage));
            Routing.RegisterRoute(nameof(OrdenesPage), typeof(OrdenesPage));
            Routing.RegisterRoute(nameof(EquiposPage), typeof(EquiposPage));
            Routing.RegisterRoute(nameof(ClientesPage), typeof(ClientesPage));
        }
    }
}


