using Microsoft.Maui.Controls;
using System;

namespace FavoriteMovies.Controls
{
    public partial class MovieRatingControl : ContentView
    {
        const int MaxStars = 5;

        public static readonly BindableProperty RatingProperty =
            BindableProperty.Create(
                nameof(Rating),
                typeof(int),
                typeof(MovieRatingControl),
                0,
                BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((MovieRatingControl)bindable).UpdateStars();
                });

        public int Rating
        {
            get => (int)GetValue(RatingProperty);
            set => SetValue(RatingProperty, value);
        }

        public MovieRatingControl()
        {
            InitializeComponent();
            BuildStars();
        }

        private void BuildStars()
        {
            StarContainer.Children.Clear();

            for (int i = 1; i <= MaxStars; i++)
            {
                var starNumber = i; // ¡Captura correcta!

                var starLabel = new Label
                {
                    Text = "☆", // estrella vacía
                    FontSize = 20,
                    TextColor = Colors.Goldenrod,
                    GestureRecognizers =
                    {
                        new TapGestureRecognizer
                        {
                            Command = new Command(() => OnStarTapped(starNumber))
                        }
                    }
                };
                StarContainer.Children.Add(starLabel);
            }

            UpdateStars();
        }

        private void UpdateStars()
        {
            for (int i = 0; i < MaxStars; i++)
            {
                var starLabel = StarContainer.Children[i] as Label;
                if (starLabel != null)
                {
                    starLabel.Text = (i < Rating) ? "⭐" : "☆";
                }
            }
        }

        private void OnStarTapped(int starNumber)
        {
            Rating = starNumber;
            // Si quieres hacer algo más con la calificación cuando cambia, puedes hacerlo aquí.
            // Por ejemplo, notificar al ViewModel que se ha cambiado la calificación.
            // _viewModel.UserRating = Rating;
        }
    }
}
