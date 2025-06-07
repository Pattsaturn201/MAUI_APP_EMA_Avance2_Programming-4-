using System;
using Microsoft.Maui.Controls;

namespace EMAMUAIAPP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnClientesClicked(object sender, EventArgs e)
        {

        }

        private async void OnEmpleadosClicked(object sender, EventArgs e)
        {

        }

        private async void OnEquiposClicked(object sender, EventArgs e)
        {

        }

        private async void OnOrdenesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrdenesPage());
        }

        private async void OnPagosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PagosPage());
        }

    }
}

