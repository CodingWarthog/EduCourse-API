using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Course
    {
        public Course()
        {
            AssetToCourseAssignment = new HashSet<AssetToCourseAssignment>();
            CourseEnrolment = new HashSet<CourseEnrolment>();
            Exam = new HashSet<Exam>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Other { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<AssetToCourseAssignment> AssetToCourseAssignment { get; set; }
        public virtual ICollection<CourseEnrolment> CourseEnrolment { get; set; }
        public virtual ICollection<Exam> Exam { get; set; }
    }
}
