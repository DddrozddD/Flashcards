using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Flashcards.Commands.DeleteFlashcard
{
    public class DeleteFlashcardCommandValidaitor : AbstractValidator<DeleteFlashcardCommand>
    {
        public DeleteFlashcardCommandValidaitor()
        {
            RuleFor(f => f.Id).NotEqual(Guid.Empty).WithMessage("Theme id id requied.");
        }
    }
}
