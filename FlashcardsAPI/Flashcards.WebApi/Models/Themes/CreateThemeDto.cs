using AutoMapper;
using Flashcards.Application.Common.Mapping;
using Flashcards.Application.Features.Themes.Commands.CreateTheme;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.WebApi.Models.Themes
{
    public class CreateThemeDto : IMapTo<CreateThemeCommand>
    {
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateThemeDto, CreateThemeCommand>()
                .ForMember(command => command.Title,
                    opt => opt.MapFrom(dto => dto.Title))
                .ForMember(command => command.Description,
                    opt => opt.MapFrom(dto => dto.Description));
        }

    }
}
