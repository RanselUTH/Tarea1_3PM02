using System;
using Tarea1_3PM02.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea1_3PM02.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEmple : ContentPage
    {
       

        public PageEmple()
        {
            InitializeComponent();
            Title = "Agregar Empleado";
        }

        Models.Empleado _employee;
        public PageEmple(Models.Empleado emple)
        {
            InitializeComponent();
            
            Title="Actualizar Empleado";

            _employee=emple;
            txtnombre.Text = emple.nombres;
            txtapellido.Text = emple.apellidos;
            txtedad.Text = Convert.ToString(emple.edad);
            txtcorreo.Text = emple.correo;
            txtdireccion.Text = emple.direccion;
            txtnombre.Focus();

            btnagregar.Text = "Actualizar empleado";

        }

        


        async void AddnewEmpleado()
        {
            var emple = new Models.Empleado
            {
                nombres = txtnombre.Text,
                apellidos = txtapellido.Text,
                edad = Convert.ToInt32(txtedad.Text),
                correo = txtcorreo.Text,
                direccion = txtdireccion.Text
            };


            if (await App.Dbemple.StoreEmple(emple) > 0)
            {
                await DisplayAlert("Aviso", "Empleado Agregado", "OK");
            }

            await Navigation.PopAsync();
        }

        async void UpdateEmployee()
        {
            _employee.nombres = txtnombre.Text; ;
            _employee.apellidos = txtapellido.Text;
            _employee.edad = Convert.ToInt32(txtedad.Text);
            _employee.correo = txtcorreo.Text;
            _employee.direccion = txtdireccion.Text;
            await App.Dbemple.StoreEmple(_employee);
            await Navigation.PopAsync();
        }

        private async void btnagregar_Clicked(object sender, EventArgs e)
        {
            //string.IsNullOrWhiteSpace(edad.Text)
            if (string.IsNullOrWhiteSpace(txtnombre.Text) || string.IsNullOrWhiteSpace(txtapellido.Text) || string.IsNullOrWhiteSpace(txtedad.Text) || string.IsNullOrWhiteSpace(txtcorreo.Text) || string.IsNullOrWhiteSpace(txtdireccion.Text))
            {
                await DisplayAlert("Invalido", "Campos Vacios", "OK");
            }
            else if (_employee != null)
            {
                UpdateEmployee();
            }
            else
                AddnewEmpleado();
        }
    }
}