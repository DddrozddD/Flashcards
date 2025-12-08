using Flashcards.Application.Common.Exceptions;
using Flashcards.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Flashcards.Application.Features.Flashcards.Commands.DeleteFlashcard
{
    
    public class DeleteFlashcardCommandHandler : IRequestHandler<DeleteFlashcardCommand, Unit>
    {
        private readonly IFlashcardsDbContext _context;
        public DeleteFlashcardCommandHandler(IFlashcardsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteFlashcardCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Flashcards.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.ThemeId != request.ThemeId)
            {
                throw new NotFoundException(nameof(Flashcards), request.Id);
            }

            _context.Flashcards.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
