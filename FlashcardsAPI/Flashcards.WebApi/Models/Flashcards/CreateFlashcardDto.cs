using Flashcards.Domain;
using Flashcards.Application.Common.Mapping;
using Flashcards.Application.Features.Flashcards.Commands.CreateFlashcard;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.WebApi.Models.Flashcards
{
    public class CreateFlashcardDto : IMapTo<CreateFlashcardCommand>
    {
        [Required]
        public string FirstValue { get; set; }
        [Required]
        public string SecondValue { get; set; }

        public string FirstDescription { get; set; }
        public string SecondDescription { get; set; }
        [Required]
        public Guid ThemeId { get; set; }
    }
}
