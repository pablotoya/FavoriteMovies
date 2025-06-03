using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavoriteMovies.Entities;
using FluentValidation;

namespace FavoriteMovies.validators
{
    public class FavoriteEntityValidator : AbstractValidator<FavoriteEntity>
    {
        public FavoriteEntityValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("El título es obligatorio.");

        RuleFor(x => x.Popularity)
            .GreaterThan(0).WithMessage("El ID debe ser mayor que 0.");

        RuleFor(x => x.FullPosterPath)
            .NotEmpty().WithMessage("La imagen es obligatoria.");

        // Agrega más validaciones si lo necesitas
    }
    }
}