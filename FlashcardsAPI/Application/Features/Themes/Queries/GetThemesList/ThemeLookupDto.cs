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
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
