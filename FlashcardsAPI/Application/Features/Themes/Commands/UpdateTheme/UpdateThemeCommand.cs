using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Themes.Commands.UpdateTheme
{
    public class UpdateThemeCommand : IRequest<Unit>
    {
        public Guid UserId;
        public Guid Id;
        public string Title;
        public string Description;
    }
}
