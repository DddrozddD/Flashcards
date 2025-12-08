using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(FlashcardsDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
        }
    }
}
