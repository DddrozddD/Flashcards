using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Flashcards.Commands.DeleteFlashcard
{
    public class DeleteFlashcardCommand : IRequest<Unit>
    {
        public Guid ThemeId { get; set; }
        public Guid Id { get; set; }
    }
}
