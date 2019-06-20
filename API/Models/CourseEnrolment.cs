using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class CourseEnrolment
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public byte[] EnrolmentDate { get; set; }

        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}
