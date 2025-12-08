using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Flashcards.Commands.UpdateFlashcard
{
    public class UpdateThemeCommandValidator : AbstractValidator<UpdateFlashcardCommand>
    {
        public UpdateThemeCommandValidator()
        {
            RuleFor(f => f.Id).NotEqual(Guid.Empty).WithMessage("Flashcard id is requred");
            RuleFor(f => f.ThemeId).NotEqual(Guid.Empty).WithMessage("Theme id is requred");
            RuleFor(f => f.FirstValue).NotEmpty().MaximumLength(250).WithMessage("First value length must not exceed 250 characters.");
            RuleFor(f => f.SecondValue).NotEmpty().MaximumLength(100).WithMessage("Second value length must not exceed 250 characters.");
        }
    }
}
