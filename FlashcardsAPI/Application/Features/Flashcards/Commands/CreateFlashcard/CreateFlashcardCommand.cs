using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Flashcards.Commands.CreateFlashcard
{
    public class CreateFlashcardCommand : IRequest<Guid>
    {
        public Guid ThemeId { get; set; }
        public string FirstValue { get; set; }
        public string FirstDescription { get; set; }
        public string SecondValue { get; set; }
        public string SecondDescription { get; set; }
    }
}
