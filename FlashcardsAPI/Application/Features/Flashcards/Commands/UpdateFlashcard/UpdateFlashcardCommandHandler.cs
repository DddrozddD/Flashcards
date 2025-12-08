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

namespace Flashcards.Application.Features.Flashcards.Commands.UpdateFlashcard
{
    public class UpdateFlashcardCommandHandler : IRequestHandler<UpdateFlashcardCommand, Unit>
    {
        private readonly IFlashcardsDbContext _context;
        public UpdateFlashcardCommandHandler(IFlashcardsDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateFlashcardCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Flashcards.FirstOrDefaultAsync(f=>f.Id == request.Id);
            if (entity == null || entity.ThemeId != request.ThemeId)
            {
                throw new NotFoundException(nameof(Flashcard), request.Id);
            }
            entity.FirstValue = request.FirstValue;
            entity.FirstDescription = request.FirstDescription;
            entity.SecondValue = request.SecondValue;
            entity.SecondDescription = request.SecondDescription;
            entity.EditDate = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
