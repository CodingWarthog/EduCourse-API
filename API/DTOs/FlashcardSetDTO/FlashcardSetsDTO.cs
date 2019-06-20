using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.FlashcardSetDTO
{
    public class FlashcardSetsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public string Other { get; set; }
        public int UserId { get; set; }
    }
}
