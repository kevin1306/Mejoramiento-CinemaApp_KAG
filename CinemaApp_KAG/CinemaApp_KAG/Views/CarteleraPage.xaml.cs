using CinemaApp_KAG.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CinemaApp_KAG.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FuncionesPage : ContentPage
	{
		public FuncionesPage (Pelicula pelicula)
		{
			InitializeComponent ();
            CargarCartelera();
		}

        private async Task CargarCartelera()
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://misapis.azurewebsites.net");

            var request = await  cliente.GetAsync("/api/Cartelera");
            if(request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<List<Pelicula>>(responseJson);
                listPelicula.ItemsSource = response;
            }

        }
        private async void Item_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var pelicula = e.SelectedItem as Pelicula;
            await Navigation.PushAsync(new FuncionesPage(pelicula));
        }
    }
}