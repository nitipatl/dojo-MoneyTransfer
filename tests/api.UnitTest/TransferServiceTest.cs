using System;
using Xunit;

namespace api.UnitTest
{
    public class TransferServiceTest
    {
        [Fact]
        public void When_Accumulated_Is_0()
        {
            bool expectedResult = true;

            TransferService transferService = TransferService();
            bool actualResult = transferService.IsAccumulated(0);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
