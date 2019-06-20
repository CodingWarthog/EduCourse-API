using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.FlashcardDTO
{
    public class FlashcardListDTO
    {
        public int Id { get; set; }
        public string Frontside { get; set; }
        public string Backside { get; set; }
        public int? Learned { get; set; }
        public int FlashcardSetId { get; set; }
    }
}
