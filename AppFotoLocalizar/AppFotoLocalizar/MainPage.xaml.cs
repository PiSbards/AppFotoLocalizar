using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppFotoLocalizar
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void btnTirar_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync();
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                foto.Source = ImageSource.FromStream(() => stream);
            }
        }
        public async Task MostrarMapa()
        {
            var location = await Geolocation.GetLocationAsync(new GeolocationRequest()
            { DesiredAccuracy = GeolocationAccuracy.Best });
            var locationinfo = new Location(location.Latitude, location.Longitude);
            var options = new MapLaunchOptions { Name = "Local da Foto" };
            await Map.OpenAsync(locationinfo, options);
        }

        async void btnLocalizar_Clicked(object sender, EventArgs e)
        {
            await MostrarMapa();
        }
    }
}
