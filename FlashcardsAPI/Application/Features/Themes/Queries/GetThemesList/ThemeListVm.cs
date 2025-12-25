using Flashcards.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Themes.Queries.GetThemesList
{
    public class ThemeListVm
    {
        public IReadOnlyCollection<ThemeLookupDto> Themes { get; set; }
        public int totalCount { get; set;}
    }
}
