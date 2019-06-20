using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class AssetToFlashcardSetAssignment
    {
        public int FlashcardSetId { get; set; }
        public int AssetId { get; set; }

        public virtual Asset Asset { get; set; }
        public virtual FlashcardSet FlashcardSet { get; set; }
    }
}
