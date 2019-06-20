using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Asset
    {
        public Asset()
        {
            AssetToCourseAssignment = new HashSet<AssetToCourseAssignment>();
            AssetToFlashcardSetAssignment = new HashSet<AssetToFlashcardSetAssignment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<AssetToCourseAssignment> AssetToCourseAssignment { get; set; }
        public virtual ICollection<AssetToFlashcardSetAssignment> AssetToFlashcardSetAssignment { get; set; }
    }
}
