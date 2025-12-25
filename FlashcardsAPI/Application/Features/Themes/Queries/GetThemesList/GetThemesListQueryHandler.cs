using AutoMapper;
using AutoMapper.QueryableExtensions;
using Flashcards.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Themes.Queries.GetThemesList
{
    public class GetThemesListQueryHandler : IRequestHandler<GetThemesListQuery, ThemeListVm>
    {
        private readonly IFlashcardsDbContext _context;
        private readonly IMapper _mapper;

       public GetThemesListQueryHandler(IFlashcardsDbContext context, IMapper mapper)
        {
           (_context, _mapper) = (context, mapper);
       }

        public async Task<ThemeListVm> Handle(GetThemesListQuery request, CancellationToken cancellationToken)
        {
            var query = await _context.Themes.Where(t => t.UserId == request.UserId).Skip((request.Page - 1) * request.Limit).Take(request.Limit).ProjectTo<ThemeLookupDto>(_mapper.ConfigurationProvider).ToListAsync();
            var themesCount = await _context.Themes.CountAsync(t => t.UserId == request.UserId);
            return new ThemeListVm { Themes = query, totalCount = themesCount };
        } 
    }
}
