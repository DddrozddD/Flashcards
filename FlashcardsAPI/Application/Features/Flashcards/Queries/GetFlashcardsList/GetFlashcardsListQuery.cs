using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Flashcards.Queries.GetFlashcardsList
{
    public class GetFlashcardsListQuery : IRequest<FlashcardsListVm>
    {
        public Guid ThemeId {  get; set; }
    }
}
