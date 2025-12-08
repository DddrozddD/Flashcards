using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flashcards.Domain;

namespace Flashcards.Application.Interfaces
{
    public interface IFlashcardsDbContext
    {
        DbSet<Flashcard> Flashcards { get; }
        DbSet<Theme> Themes { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
