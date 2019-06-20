using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class educoursedbContext : DbContext
    {
        public educoursedbContext()
        {
        }

        public educoursedbContext(DbContextOptions<educoursedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asset> Asset { get; set; }
        public virtual DbSet<AssetToCourseAssignment> AssetToCourseAssignment { get; set; }
        public virtual DbSet<AssetToFlashcardSetAssignment> AssetToFlashcardSetAssignment { get; set; }
        public virtual DbSet<BadgeAssignment> BadgeAssignment { get; set; }
        public virtual DbSet<Badges> Badges { get; set; }
        public virtual DbSet<BlockItem> BlockItem { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseEnrolment> CourseEnrolment { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<ExamResult> ExamResult { get; set; }
        public virtual DbSet<Experience> Experience { get; set; }
        public virtual DbSet<Flashcard> Flashcard { get; set; }
        public virtual DbSet<FlashcardSet> FlashcardSet { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PublicId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Asset)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ASSET_REFERENCE_USER");
            });

            modelBuilder.Entity<AssetToCourseAssignment>(entity =>
            {
                entity.HasKey(e => new { e.AssetId, e.CourseId })
                    .HasName("PK_ASSETTOCOURSEASSIGNMENT");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetToCourseAssignment)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASSETTOC_REFERENCE_ASSET");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.AssetToCourseAssignment)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASSETTOC_REFERENCE_COURSE");
            });

            modelBuilder.Entity<AssetToFlashcardSetAssignment>(entity =>
            {
                entity.HasKey(e => new { e.FlashcardSetId, e.AssetId })
                    .HasName("PK_ASSETTOFLASHCARDSETASSIGNME");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetToFlashcardSetAssignment)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASSETTOF_REFERENCE_ASSET");

                entity.HasOne(d => d.FlashcardSet)
                    .WithMany(p => p.AssetToFlashcardSetAssignment)
                    .HasForeignKey(d => d.FlashcardSetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASSETTOF_REFERENCE_FLASHCAR");
            });

            modelBuilder.Entity<BadgeAssignment>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BadgeId })
                    .HasName("PK_BADGEASSIGNMENT");

                entity.Property(e => e.CreatedAt).IsRowVersion();

                entity.HasOne(d => d.Badge)
                    .WithMany(p => p.BadgeAssignment)
                    .HasForeignKey(d => d.BadgeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BADGEASS_REFERENCE_BADGES");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BadgeAssignment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BADGEASS_REFERENCE_USER");
            });

            modelBuilder.Entity<Badges>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Badges)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_BADGES_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<BlockItem>(entity =>
            {
                entity.Property(e => e.Content).HasColumnType("text");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.BlockItem)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK_BLOCKITE_REFERENCE_EXAM");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Other)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_COURSE_REFERENCE_CATEGORY");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_COURSE_REFERENCE_USER");
            });

            modelBuilder.Entity<CourseEnrolment>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CourseId })
                    .HasName("PK_COURSEENROLMENT");

                entity.Property(e => e.EnrolmentDate).IsRowVersion();

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseEnrolment)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COURSEEN_REFERENCE_COURSE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CourseEnrolment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COURSEEN_REFERENCE_USER");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.Property(e => e.Level)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Exam)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_EXAM_REFERENCE_COURSE");
            });

            modelBuilder.Entity<ExamResult>(entity =>
            {
                entity.Property(e => e.Mark)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.ExamResult)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EXAMRESU_REFERENCE_EXAM");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExamResult)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EXAMRESU_REFERENCE_USER");
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Experience)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_EXPERIEN_REFERENCE_CATEGORY");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Experience)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_EXPERIEN_REFERENCE_USER");
            });

            modelBuilder.Entity<Flashcard>(entity =>
            {
                entity.Property(e => e.BackSide)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FrontSide)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.FlashcardSet)
                    .WithMany(p => p.Flashcard)
                    .HasForeignKey(d => d.FlashcardSetId)
                    .HasConstraintName("FK_FLASHCAR_REFERENCE_FLASHCAR");
            });

            modelBuilder.Entity<FlashcardSet>(entity =>
            {
                entity.Property(e => e.CreatedAt).IsRowVersion();

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Level)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Other)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FlashcardSet)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_FLASHCAR_REFERENCE_USER");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Answer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OptionFour)
                    .HasColumnName("Option_four")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OptionOne)
                    .HasColumnName("Option_one")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OptionThree)
                    .HasColumnName("Option_three")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OptionTwo)
                    .HasColumnName("Option_two")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Question1)
                    .HasColumnName("Question")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK_QUESTION_REFERENCE_EXAM");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash).HasMaxLength(500);

                entity.Property(e => e.PasswordSalt).HasMaxLength(500);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
