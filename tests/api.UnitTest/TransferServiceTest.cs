using System;
using Xunit;
using api.Services;

namespace api.UnitTest
{
    public class TransferServiceTest
    {
        [Theory]
        [InlineData(0.00)]
        [InlineData(500.00)]
        [InlineData(100000.00)]
        public void When_Accumulated_Between_0_And_100000(double accumulatedNumber)
        {
            bool expectedResult = true;

            TransferService transferService = new TransferService();
            bool actualResult = transferService.IsAccumulated(accumulatedNumber);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
