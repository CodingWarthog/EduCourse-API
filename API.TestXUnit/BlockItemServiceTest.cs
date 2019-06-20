using API.DTOs.BlockItemDTO;
using API.Services.BlockItems;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace API.TestXUnit
{
    public class BlockItemServiceTest
    {
        private readonly Mock<IBlockItemService> _blockItemServiceMock;

        public BlockItemServiceTest()
        {
            _blockItemServiceMock = new Mock<IBlockItemService>();
        }

    [Fact]
        public void GetBlockItemAsyncTest()
        {
            int inputTestedId = 4;

            BlockItemForListDTO expectedOutput = new BlockItemForListDTO();
            expectedOutput.Id = 4;
            expectedOutput.Content = " Francusko-brytyjska konferencja polityczno-wojskowa w Abbeville";
            expectedOutput.BlockPosition = 4;
            expectedOutput.ExamId = 16;

            _blockItemServiceMock.Setup(r => r.GetBlockItemAsync(inputTestedId)).ReturnsAsync(expectedOutput);
            var result = _blockItemServiceMock.Object.GetBlockItemAsync(inputTestedId).Result;

            Assert.Equal(expectedOutput, result);
        }
    }
}
