using AutoMapper;
using Flashcards.Application.Interfaces;
using Flashcards.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Application.Features.Themes.Commands.CreateTheme
{
    public class CreateThemeCommandHandler : IRequestHandler<CreateThemeCommand, Guid>
    {
        private readonly IFlashcardsDbContext _context;

        public CreateThemeCommandHandler(IFlashcardsDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateThemeCommand command, CancellationToken cancellationToken)
        {
            var theme = new Theme
            {
                UserId = command.UserId,
                Title = command.Title,
                Description = command.Description
            };

            await _context.Themes.AddAsync(theme, cancellationToken);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return theme.Id;
        }

    }
}
