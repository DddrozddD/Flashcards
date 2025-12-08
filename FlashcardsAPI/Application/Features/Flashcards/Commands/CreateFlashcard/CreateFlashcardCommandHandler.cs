using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flashcards.Domain;
using Flashcards.Application.Interfaces;

namespace Flashcards.Application.Features.Flashcards.Commands.CreateFlashcard
{
    public class CreateFlashcardCommandHandler : IRequestHandler<CreateFlashcardCommand, Guid>
    {
        private readonly IFlashcardsDbContext _context;
        public CreateFlashcardCommandHandler(IFlashcardsDbContext context) 
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateFlashcardCommand request, CancellationToken cancellationToken)
        {
            var entity = new Flashcard
            {
                Id = Guid.NewGuid(),
                ThemeId = request.ThemeId,
                FirstValue = request.FirstValue,
                SecondValue = request.SecondValue,
                CreationDate = DateTime.UtcNow,
                EditDate = null
            };
            _context.Flashcards.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
