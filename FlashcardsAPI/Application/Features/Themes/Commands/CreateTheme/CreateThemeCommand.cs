using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Themes.Commands.CreateTheme
{
    public class CreateThemeCommand : IRequest<Guid>
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

    }
}
