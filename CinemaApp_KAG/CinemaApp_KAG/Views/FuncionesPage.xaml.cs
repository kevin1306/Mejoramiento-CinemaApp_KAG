using CinemaApp_KAG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CinemaApp_KAG.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FuncionesPage : ContentPage
	{
        private ResumenCompra resumencompra;

         Pelicula PeliculaElegida = new Pelicula();

        public FuncionesPage (Pelicula FuncionPelicula)
		{
			InitializeComponent ();
            BindingContext = FuncionPelicula;
            var PeliculaElegida = new Pelicula();
            PeliculaElegida = FuncionPelicula;
		}

        private async void  Item_Selected(object sender, SelectedItemChangedEventArgs e)
        {

            var funcionSeleccionada = e.SelectedItem as Funcion;
            if (CantidadBoletas.Text== null)
            {

                DisplayAlert("ERROR", "Digite Cantidad de Boletas ", "OK");
                return;
            }
            int boletas = Convert.ToInt32(CantidadBoletas.Text);

            int totalBoletas = boletas * funcionSeleccionada.Precio;

            ResumenCompra resumenCompra = new ResumenCompra();

            resumenCompra.funcion = funcionSeleccionada;
            resumenCompra.pelicula = PeliculaElegida;
            resumenCompra.cantidad = boletas;
            resumenCompra.total = totalBoletas;

            await Navigation.PushAsync(new ResumenCompraPage(resumencompra));
        }
	}
}