using CinemaApp_KAG.Models;
using CinemaApp_KAG.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinema_ALH.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FuncionesPage : ContentPage
    {
        Pelicula peliculaElegida = new Pelicula();

        public FuncionesPage(Pelicula funcionPelicula)
        {
            InitializeComponent ();
            BindingContext = funcionPelicula;
            peliculaElegida = funcionPelicula;

        }

        private async void Item_Selected(object sender, SelectedItemChangedEventArgs e)
        {

            var funcionSeleccionada = e.SelectedItem as Funcion;

            if (CantidadBoletas.Text == null)
            {
                DisplayAlert("ERROR", "Digite la cantidad de boletas", "OK");
                return;
            }
            int boletas = Convert.ToInt32(CantidadBoletas.Text);

            int total = boletas * funcionSeleccionada.Precio;

            ResumenCompra resumencompra = new ResumenCompra();

            resumencompra.funcion = funcionSeleccionada;
            resumencompra.pelicula = peliculaElegida;
            resumencompra.cantidad = boletas;
            resumencompra.total = total;


            await Navigation.PushAsync(new ResumenCompraPage(resumencompra));
        }





    }
}