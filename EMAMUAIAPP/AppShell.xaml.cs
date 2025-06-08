using System;
using Microsoft.Maui.Controls;

namespace EMAMUAIAPP
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(ClientesPage), typeof(ClientesPage));
            Routing.RegisterRoute(nameof(ClienteFormularioPage), typeof(ClienteFormularioPage));
            Routing.RegisterRoute(nameof(EquiposPage), typeof(EquiposPage));
            Routing.RegisterRoute(nameof(EquipoFormularioPage), typeof(EquipoFormularioPage));

        }
    }
}




