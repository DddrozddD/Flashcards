using AutoMapper;
using Flashcards.Application.Common.Exceptions;
using Flashcards.Application.Interfaces;
using Flashcards.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Themes.Queries.GetThemeDetails
{
    public class GetThemeDetailsQueryHandler : IRequestHandler<GetThemeDetailsQuery, ThemeDetailsVm>
    {
        private readonly IFlashcardsDbContext _context;
        private readonly IMapper _mapper;

        public GetThemeDetailsQueryHandler(IFlashcardsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ThemeDetailsVm> Handle(GetThemeDetailsQuery request, CancellationToken cancellationToken)
        {
            var query = await _context.Themes.FirstOrDefaultAsync(t=>t.Id==request.Id);
            if (query == null || query.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Theme), request.Id);
            }

            return _mapper.Map<ThemeDetailsVm>(query);
        }
    }
}
