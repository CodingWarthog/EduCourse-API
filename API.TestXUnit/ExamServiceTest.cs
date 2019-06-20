using API.DTOs.ExamDTO;
using API.Services.Exams;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace API.TestXUnit
{
    public class ExamServiceTest
    {
        private readonly Mock<IExamService> _examServiceMock;

        public ExamServiceTest()
        {
            _examServiceMock = new Mock<IExamService>();
        }

        [Fact]
        public void GetExamsCreatedByUserAsyncTest()
        {
            int inputTestedId = 3;

            var expectedValue1 = new ExamGetDTO();
            expectedValue1.Id = 2;
            expectedValue1.Name = "Daty";
            expectedValue1.TimeLimit = 10;
            expectedValue1.TotalExamPoints = 10;
            expectedValue1.NumberOfQuestions = 10;
            expectedValue1.Level = "Poziom sredniozaawansowany";
            expectedValue1.Type = "Zwykly";
            expectedValue1.CourseId = 3;

            var expectedValue2 = new ExamGetDTO();
            expectedValue2.Id = 9;
            expectedValue2.Name = "Starozytna Grecja";
            expectedValue2.TimeLimit = 5;
            expectedValue2.TotalExamPoints = 10;
            expectedValue2.NumberOfQuestions = 10;
            expectedValue2.Level = "Poziom podstawowy";
            expectedValue2.Type = "Zwykly";
            expectedValue2.CourseId = 3;

            List<ExamGetDTO> expextedOutputList = new List<ExamGetDTO>();
            expextedOutputList.Add(expectedValue1);
            expextedOutputList.Add(expectedValue2);

            _examServiceMock.Setup(r => r.GetExamsCreatedByUserAsync(inputTestedId)).ReturnsAsync(expextedOutputList);
            var result = _examServiceMock.Object.GetExamsCreatedByUserAsync(inputTestedId).Result;

            Assert.Equal(expextedOutputList, result);
        }
    }
}
