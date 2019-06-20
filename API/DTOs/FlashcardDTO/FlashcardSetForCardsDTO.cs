using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.FlashcardDTO
{
    public class FlashcardSetForCardsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<FlashcardListDTO> Flashcard { get; set; }
    }
}
