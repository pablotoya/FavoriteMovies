using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteMovies.Converts
{
    public class RatingToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            

            if (value != null && int.TryParse(value.ToString(), out int result))
            
                

            // Devuelve colores distintos según el rating (de 1 a 5)
            return result switch
            {
                >= 4 => Colors.Gold,
                3 => Colors.Orange,
                2 => Colors.DarkOrange,
                1 => Colors.DarkRed,
                _ => Colors.LightGray
            };
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}