using Flashcards.Application.Common.Mapping;
using Flashcards.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Flashcards.Queries.GetFlashcardDetails
{
    public class FlashcardDetailsVm : IMapWith<Flashcard>
    {
        public Guid Id { get; set; }
        public string FirstVlue { get; set; }
        public string FirstDescription { get; set; }
        public string SecondValue   { get; set; }
        public string SecondDescription { get; set; }
    }
}
