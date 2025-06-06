using System.Collections.ObjectModel;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;



namespace FavoriteMovies.Controls;

public partial class CustomMapControl : ContentView
{
    public static readonly BindableProperty UbicacionProperty =
        BindableProperty.Create(nameof(Ubicacion), typeof(Location), typeof(CustomMapControl), null, propertyChanged: OnUbicacionChanged);

    public static readonly BindableProperty PinesProperty =
        BindableProperty.Create(nameof(Pines), typeof(IEnumerable<Pin>), typeof(CustomMapControl), null, propertyChanged: OnPinesChanged);

    private readonly Map _map;

    public CustomMapControl()
    {
        _map = new Map
        {
            IsShowingUser = true,
            MapType = MapType.Street
        };

        Content = _map;
    }

    public Location Ubicacion
    {
        get => (Location)GetValue(UbicacionProperty);
        set => SetValue(UbicacionProperty, value);
    }

    public IEnumerable<Pin> Pines
    {
        get => (IEnumerable<Pin>)GetValue(PinesProperty);
        set => SetValue(PinesProperty, value);
    }

    private static void OnUbicacionChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is CustomMapControl control && newValue is Location location)
        {
            control._map.MoveToRegion(MapSpan.FromCenterAndRadius(
                location, Distance.FromKilometers(1)));
        }
    }

    private static void OnPinesChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is CustomMapControl control)
        {
            control._map.Pins.Clear();
            if (newValue is IEnumerable<Pin> pines)
            {
                foreach (var pin in pines)
                {
                    control._map.Pins.Add(pin);
                }
            }
        }
    }
}
