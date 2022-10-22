using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea1_3PM02.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePrincipal : ContentPage
    {
        public PagePrincipal()
        {
            InitializeComponent();

            Title = "Lista de Empleados";
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listemple.ItemsSource = await App.Dbemple.ListaEmpleadosAll();

        }

        private void listemple_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           //sin codigo
        }

        private async void tlbadd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageEmple());
        }

        private void tlbmapa_Clicked(object sender, EventArgs e)
        {
                //sin codigo
        }

        private async void btnupdate_Clicked(object sender, EventArgs e)
        {
            var item = sender as Button;
            var emple = item.CommandParameter as Models.Empleado;
            await Navigation.PushAsync(new PageEmple(emple));
        }

        private async void btndelete_Clicked(object sender, EventArgs e)
        {
            
            
            var item = sender as Button;
            var emple = item.CommandParameter as Models.Empleado;
            var result = await DisplayAlert("Borrar", $"Borrar {emple.nombres} de la base de datos", "SI", "NO");
            if (result)
            {
                await App.Dbemple.DeleteEmple(emple);
                listemple.ItemsSource = await App.Dbemple.ListaEmpleadosAll();
            }
        }
    }
}