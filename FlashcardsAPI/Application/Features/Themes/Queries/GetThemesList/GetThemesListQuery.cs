using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Themes.Queries.GetThemesList
{
    public class GetThemesListQuery : IRequest<ThemeListVm>
    {
        public Guid UserId { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }

    }
}
