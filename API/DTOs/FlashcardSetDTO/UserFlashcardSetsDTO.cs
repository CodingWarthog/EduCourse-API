using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.FlashcardSetDTO
{
    public class UserFlashcardSetsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<FlashcardSetsDTO> FlashcardSet { get; set; }
    }
}
