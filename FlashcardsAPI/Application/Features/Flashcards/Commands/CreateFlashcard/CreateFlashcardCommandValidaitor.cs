using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Flashcards.Commands.CreateFlashcard
{
    public class CreateFlashcardCommandValidaitor : AbstractValidator<CreateFlashcardCommand>
    {
        public CreateFlashcardCommandValidaitor()
        {
            RuleFor(c=>c.FirstValue).NotEmpty().WithMessage("First value is required.")
                .MaximumLength(250).WithMessage("First value length must not exceed 250 characters.");

            RuleFor(c => c.SecondValue).NotEmpty().WithMessage("Second value is required.")
                .MaximumLength(250).WithMessage("Second value length must not exceed 250 characters.");
            
            RuleFor(c => c.ThemeId).NotEmpty().WithMessage("ThemeId is required.");
        }
    }
}
