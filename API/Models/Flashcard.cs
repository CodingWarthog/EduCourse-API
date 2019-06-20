using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Flashcard
    {
        public int Id { get; set; }
        public string FrontSide { get; set; }
        public string BackSide { get; set; }
        public int FlashcardSetId { get; set; }

        public virtual FlashcardSet FlashcardSet { get; set; }
    }
}
