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
    public class ThemeConfiguration : IEntityTypeConfiguration<Theme>
    {
            public void Configure(EntityTypeBuilder<Theme> builder)
            {
                builder.HasKey(t => t.Id);
                builder.HasIndex(t => t.Id).IsUnique();
                builder.Property(t => t.Title).HasMaxLength(150);
                builder.Property(t => t.Description).HasMaxLength(1500);
                builder.HasMany(t=>t.Flashcards).WithOne(f=>f.Theme).HasForeignKey(f=>f.ThemeId);
            }
    }
}
