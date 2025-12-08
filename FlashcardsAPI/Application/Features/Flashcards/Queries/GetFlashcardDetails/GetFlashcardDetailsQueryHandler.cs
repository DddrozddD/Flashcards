using AutoMapper;
using Flashcards.Application.Common.Exceptions;
using Flashcards.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Flashcards.Queries.GetFlashcardDetails
{
    public class GetFlashcardDetailsQueryHandler : IRequestHandler<GetFlashcardDetailsQuery, FlashcardDetailsVm>
    {
        private readonly IFlashcardsDbContext _context;
        private readonly IMapper _mapper;

        public GetFlashcardDetailsQueryHandler(IFlashcardsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FlashcardDetailsVm> Handle(GetFlashcardDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Flashcards.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);
            if(entity == null || entity.ThemeId != request.ThemeId )
            {
                throw new NotFoundException(nameof(FlashcardDetailsVm), request.Id);
            }

            return _mapper.Map<FlashcardDetailsVm>(entity);
        }
    }
}
