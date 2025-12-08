using Flashcards.Application.Common.Mapping;
using Flashcards.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Themes.Queries.GetThemesList
{
    public class ThemeLookupDto : IMapWith<Theme>
    {
        public string Title { get; set; }
    }
}
