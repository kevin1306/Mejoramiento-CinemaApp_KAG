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
	public partial class ResumenCompraPage : ContentPage
	{
		public ResumenCompraPage (ResumenCompra resumen)
		{
			InitializeComponent ();
            BindingContext = resumen;
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("COMPRA CON EXITO ", "lA RESERVA SE HA GENERADO CORRECTAMENTE", "OK");
            return;
        }
    }
}