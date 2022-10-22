using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea1_3PM02.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageTwo : ContentPage
    {
        public PageTwo()
        {
            InitializeComponent();
        }

        public PageTwo(String pmessage)
        {
            InitializeComponent();

            lbcorreo.Text = pmessage;
        }
    }
}