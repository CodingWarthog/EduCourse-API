using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class User
    {
        public User()
        {
            Asset = new HashSet<Asset>();
            BadgeAssignment = new HashSet<BadgeAssignment>();
            Course = new HashSet<Course>();
            CourseEnrolment = new HashSet<CourseEnrolment>();
            ExamResult = new HashSet<ExamResult>();
            Experience = new HashSet<Experience>();
            FlashcardSet = new HashSet<FlashcardSet>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Asset> Asset { get; set; }
        public virtual ICollection<BadgeAssignment> BadgeAssignment { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<CourseEnrolment> CourseEnrolment { get; set; }
        public virtual ICollection<ExamResult> ExamResult { get; set; }
        public virtual ICollection<Experience> Experience { get; set; }
        public virtual ICollection<FlashcardSet> FlashcardSet { get; set; }
    }
}
