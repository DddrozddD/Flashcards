using Flashcards.Domain;
using Flashcards.Application.Interfaces;
using Flashcards.Domain;
using Flashcards.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Persistence
{
    public class FlashcardsDbContext : DbContext, IFlashcardsDbContext
    {
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Flashcard> Flashcards { get; set; }
        public FlashcardsDbContext(DbContextOptions<FlashcardsDbContext> options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlashcardConfiguration());
            modelBuilder.ApplyConfiguration(new ThemeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
