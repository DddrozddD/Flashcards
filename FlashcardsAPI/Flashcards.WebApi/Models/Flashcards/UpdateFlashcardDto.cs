using Flashcards.Application.Common.Mapping;
using Flashcards.Application.Features.Flashcards.Commands.UpdateFlashcard;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.WebApi.Models.Flashcards
{
    public class UpdateFlashcardDto : IMapTo<UpdateFlashcardCommand>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string FirstValue { get; set; }
        [Required]
        public string SecondValue { get; set; }
        public string FirstDescription { get; set; }
        public string SecondDescription { get; set; }
    }
}
