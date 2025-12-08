using Flashcards.Application.Common.Mapping;
using Flashcards.Application.Features.Themes.Commands.CreateTheme;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.WebApi.Models.Themes
{
    public class CreateThemeDto : IMapWith<CreateThemeCommand>
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        
    }
}
