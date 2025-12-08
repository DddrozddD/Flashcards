using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Flashcards.Queries.GetFlashcardDetails
{
    public class GetFlashcardDetailsQuery : IRequest<FlashcardDetailsVm>
    {
        public Guid ThemeId { get; set; }
        public Guid Id { get; set; }

    }
}
