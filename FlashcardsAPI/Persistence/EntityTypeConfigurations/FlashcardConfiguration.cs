using Flashcards.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Flashcards.Persistence.EntityTypeConfigurations
{
    public class FlashcardConfiguration : IEntityTypeConfiguration<Flashcard>
    {
        public void Configure(EntityTypeBuilder<Flashcard> builder)
        {
            builder.HasKey(f => f.Id);
            builder.HasIndex(f => f.Id).IsUnique();
            builder.Property(f => f.FirstValue).HasMaxLength(150);
            builder.Property(f => f.SecondValue).HasMaxLength(150);
        }

    }
}
