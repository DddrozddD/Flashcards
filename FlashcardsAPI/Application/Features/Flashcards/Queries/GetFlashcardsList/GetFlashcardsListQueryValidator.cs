using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Flashcards.Queries.GetFlashcardsList
{
    public class GetFlashcardsListQueryValidator : AbstractValidator<GetFlashcardsListQuery>
    {
        public GetFlashcardsListQueryValidator()
        {
            RuleFor(q => q.ThemeId).NotEqual(Guid.Empty).WithMessage("Theme id cannot be empty.");
        }
    }
}
