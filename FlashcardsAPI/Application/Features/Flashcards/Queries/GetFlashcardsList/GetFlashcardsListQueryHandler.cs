using AutoMapper;
using AutoMapper.QueryableExtensions;
using Flashcards.Application.Features.Flashcards.Queries.GetFlashcardsList;
using Flashcards.Application.Interfaces;
using Flashcards.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Some.Flashcards.Queries.GetFlashcardsList
{
    public class GetFlashcardsListQueryHandler : IRequestHandler<GetFlashcardsListQuery, FlashcardsListVm>
    {
        private readonly IFlashcardsDbContext _context; 
        private readonly IMapper _mapper;

        public GetFlashcardsListQueryHandler(IFlashcardsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<FlashcardsListVm> Handle(GetFlashcardsListQuery request, CancellationToken cancellationToken)
        {
            var  query = await _context.Flashcards.Where(f => f.ThemeId == request.ThemeId)
                .ProjectTo<FlashcardLookupDto>(_mapper.ConfigurationProvider).ToListAsync();
            return new FlashcardsListVm { FlashcardsList = query };
        }

    }
}
