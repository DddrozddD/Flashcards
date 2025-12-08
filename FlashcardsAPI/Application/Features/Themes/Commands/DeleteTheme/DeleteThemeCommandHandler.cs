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

namespace Flashcards.Application.Features.Themes.Commands.DeleteTheme
{
    public class DeleteThemeCommandHandler : IRequestHandler<DeleteThemeCommand, Unit>
    {
        private readonly IFlashcardsDbContext _context;
    
        public DeleteThemeCommandHandler(IFlashcardsDbContext context) => _context = context;

        public async Task<Unit> Handle(DeleteThemeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Themes.FirstOrDefaultAsync(t=> t.Id == request.Id);
            if(entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Theme), request.Id);
            }

            _context.Themes.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    
    }

}
