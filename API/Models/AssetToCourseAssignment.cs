using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class AssetToCourseAssignment
    {
        public int AssetId { get; set; }
        public int CourseId { get; set; }

        public virtual Asset Asset { get; set; }
        public virtual Course Course { get; set; }
    }
}
