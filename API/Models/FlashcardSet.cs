using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class FlashcardSet
    {
        public FlashcardSet()
        {
            AssetToFlashcardSetAssignment = new HashSet<AssetToFlashcardSetAssignment>();
            Flashcard = new HashSet<Flashcard>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public string Other { get; set; }
        public byte[] CreatedAt { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<AssetToFlashcardSetAssignment> AssetToFlashcardSetAssignment { get; set; }
        public virtual ICollection<Flashcard> Flashcard { get; set; }
    }
}
