using Flashcards.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Domain
{
    public class Flashcard
    {
        public Guid Id { get; set; }
        public Guid ThemeId { get; set; }
        public Theme Theme { get; set; }
        public string FirstValue { get; set; }
        public string FirstDescription { get; set; }
        public string SecondValue { get; set; }
        public string SecondDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
