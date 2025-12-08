using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Flashcards.Commands.UpdateFlashcard
{
    public class UpdateFlashcardCommand : IRequest<Unit>
    {
        public Guid ThemeId { get; set; } 
        public Guid Id { get; set; }
        public string FirstValue { get; set; }
        public string FirstDescription { get; set; }
        public string SecondValue { get; set; }
        public string SecondDescription { get; set; }
    }
}
