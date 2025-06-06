using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Threading.Tasks;

namespace FavoriteMovies.ViewModels
{
    
    public partial class FavoriteLocationViewModel : ObservableObject
    {
        [ObservableProperty]
        private Location _ubicacion;

        [ObservableProperty]
        private ObservableCollection<Pin> _pins;

        public FavoriteLocationViewModel()
        {
            
            ToLocalFavorite();
           
        }
        public async void ToLocalFavorite()
        {
            try
            {

               

                var location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium));
                if (location != null)
                {
                    Ubicacion = new Location(location.Latitude, location.Longitude);
                    
                    var pin = new Pin
                    {
                        Label = "Ubicacion Actual",
                        Address = "Tu Ubicacion actual",
                        Location = Ubicacion,
                        Type = PinType.Place

                    };
                    Pins.Add(pin);
                }
            } catch (Exception ex ) {
                Console.WriteLine($"Error obteniendo ubicación: {ex.Message}");
            }
        }
    }
}
