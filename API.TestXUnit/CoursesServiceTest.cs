using API.DTOs.CourseDTO;
using API.Services.Courses;
using Moq;
using Xunit;

namespace API.TestXUnit
{
    public class CoursesServiceTest
    {
          private readonly Mock<ICoursesService> _coursesServiceMock;

          public CoursesServiceTest()
          {
              _coursesServiceMock = new Mock<ICoursesService>();
          }
          
        //sprawdza czy "wyjmuje" poprawne dane z bazy
        [Fact]
        public void GetCourseAsyncTest()
        {
            int inputTestedId = 3;

            var expectedOutput = new CourseForAddDTO();
            expectedOutput.Id = 3;
            expectedOutput.Name = "Historia Polski";
            expectedOutput.Description = "2 wojna swiatowa";
            expectedOutput.Other = "kampania wrzesniowa";
            expectedOutput.CategoryId = 1;
            expectedOutput.UserId = 6;

            _coursesServiceMock.Setup(r => r.GetCourseAsync(inputTestedId)).ReturnsAsync(expectedOutput);
            var result = _coursesServiceMock.Object.GetCourseAsync(inputTestedId).Result;

            Assert.Equal(expectedOutput, result);
            //Assert.Equal(expectedOutput.Id,  courseService.Object.GetCourseAsync(3).Result.Id);
        }

        //sprawdza czy jest kurs o podanym id
       [Fact]
        public void FindCourseTest()
        {

            int inputCourseId = 3;
            bool expectedOutput = true;

            _coursesServiceMock.Setup(r => r.FindCourse(inputCourseId)).ReturnsAsync(expectedOutput);

            var result = _coursesServiceMock.Object.FindCourse(inputCourseId).Result;

            Assert.Equal(expectedOutput, result);
        }
    }
}
