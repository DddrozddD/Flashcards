using Flashcards.Application.Common.Mapping;
using Flashcards.Application.Features.Themes.Commands.UpdateTheme;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.WebApi.Models.Themes
{
    public class UpdateThemeDto : IMapTo<UpdateThemeCommand>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
