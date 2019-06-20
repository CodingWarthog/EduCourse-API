using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class EFCoreCodeFirstSampleModelseducoursedbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Lastname = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Username = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PasswordHash = table.Column<byte[]>(maxLength: 500, nullable: true),
                    PasswordSalt = table.Column<byte[]>(maxLength: 500, nullable: true),
                    Role = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ExperiencePoints = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    Image = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BADGES_REFERENCE_CATEGORY",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Type = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    PublicId = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ASSET_REFERENCE_USER",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Other = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COURSE_REFERENCE_CATEGORY",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COURSE_REFERENCE_USER",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExperiencePoints = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EXPERIEN_REFERENCE_CATEGORY",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EXPERIEN_REFERENCE_USER",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlashcardSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Level = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    Other = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CreatedAt = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashcardSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FLASHCAR_REFERENCE_USER",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BadgeAssignment",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    BadgeId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BADGEASSIGNMENT", x => new { x.UserId, x.BadgeId });
                    table.ForeignKey(
                        name: "FK_BADGEASS_REFERENCE_BADGES",
                        column: x => x.BadgeId,
                        principalTable: "Badges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BADGEASS_REFERENCE_USER",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetToCourseAssignment",
                columns: table => new
                {
                    AssetId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSETTOCOURSEASSIGNMENT", x => new { x.AssetId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_ASSETTOC_REFERENCE_ASSET",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ASSETTOC_REFERENCE_COURSE",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseEnrolment",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    EnrolmentDate = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COURSEENROLMENT", x => new { x.UserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_COURSEEN_REFERENCE_COURSE",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COURSEEN_REFERENCE_USER",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    TimeLimit = table.Column<int>(nullable: false),
                    TotalExamPoints = table.Column<int>(nullable: false),
                    NumberOfQuestions = table.Column<int>(nullable: false),
                    Level = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Type = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EXAM_REFERENCE_COURSE",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetToFlashcardSetAssignment",
                columns: table => new
                {
                    FlashcardSetId = table.Column<int>(nullable: false),
                    AssetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSETTOFLASHCARDSETASSIGNME", x => new { x.FlashcardSetId, x.AssetId });
                    table.ForeignKey(
                        name: "FK_ASSETTOF_REFERENCE_ASSET",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ASSETTOF_REFERENCE_FLASHCAR",
                        column: x => x.FlashcardSetId,
                        principalTable: "FlashcardSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flashcard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FrontSide = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    BackSide = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    FlashcardSetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flashcard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FLASHCAR_REFERENCE_FLASHCAR",
                        column: x => x.FlashcardSetId,
                        principalTable: "FlashcardSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlockItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "text", nullable: true),
                    BlockPosition = table.Column<int>(nullable: false),
                    ExamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BLOCKITE_REFERENCE_EXAM",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Mark = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Points = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ExamId = table.Column<int>(nullable: false),
                    TotalExamPoints = table.Column<int>(nullable: false),
                    Percentage = table.Column<int>(nullable: false),
                    ExamName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EXAMRESU_REFERENCE_EXAM",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EXAMRESU_REFERENCE_USER",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Answer = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Option_one = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Option_two = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Option_three = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Option_four = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ExamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QUESTION_REFERENCE_EXAM",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_UserId",
                table: "Asset",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetToCourseAssignment_CourseId",
                table: "AssetToCourseAssignment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetToFlashcardSetAssignment_AssetId",
                table: "AssetToFlashcardSetAssignment",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_BadgeAssignment_BadgeId",
                table: "BadgeAssignment",
                column: "BadgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_CategoryId",
                table: "Badges",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockItem_ExamId",
                table: "BlockItem",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CategoryId",
                table: "Course",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_UserId",
                table: "Course",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolment_CourseId",
                table: "CourseEnrolment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_CourseId",
                table: "Exam",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResult_ExamId",
                table: "ExamResult",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResult_UserId",
                table: "ExamResult",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_CategoryId",
                table: "Experience",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_UserId",
                table: "Experience",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Flashcard_FlashcardSetId",
                table: "Flashcard",
                column: "FlashcardSetId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashcardSet_UserId",
                table: "FlashcardSet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ExamId",
                table: "Question",
                column: "ExamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetToCourseAssignment");

            migrationBuilder.DropTable(
                name: "AssetToFlashcardSetAssignment");

            migrationBuilder.DropTable(
                name: "BadgeAssignment");

            migrationBuilder.DropTable(
                name: "BlockItem");

            migrationBuilder.DropTable(
                name: "CourseEnrolment");

            migrationBuilder.DropTable(
                name: "ExamResult");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "Flashcard");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "Badges");

            migrationBuilder.DropTable(
                name: "FlashcardSet");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
