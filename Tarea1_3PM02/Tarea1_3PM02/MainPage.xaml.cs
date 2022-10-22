using System;
using Xamarin.Forms;

namespace Tarea1_3PM02
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btninf_Clicked(object sender, EventArgs e)
        {
            var emple = new Models.Empleado
            {
                nombres = txtnombre.Text,
                apellidos = txtapellido.Text,
                edad = Convert.ToInt32(txtedad.Text),
                correo = txtcorreo.Text,
                direccion = txtdireccion.Text
            };

            var page = new Views.PageTwo();
            page.BindingContext = emple;
            await Navigation.PushAsync(page);
        }
    }
}
