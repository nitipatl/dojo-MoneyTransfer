using System;
using Xunit;
using api.Services;

namespace api.UnitTest
{
    public class TransferServiceTest
    {
        [Theory]
        [InlineData(0.00, true)]
        [InlineData(500.00, true)]
        [InlineData(100000.00, false)]
        public void When_Accumulated_Between_0_And_100000(double accumulatedNumber, bool expectedResult)
        {
            TransferService transferService = new TransferService();
            bool actualResult = transferService.IsAccumulated(accumulatedNumber);

            Assert.Equal(expectedResult, actualResult);
        }

        
        [Theory]
        [InlineData(0.00, false)]
        [InlineData(500.00, true)]
        [InlineData(20000.00, true)]
        [InlineData(20001.00, false)]
        public void When_TransferAmount_Between_1_And_20000(double transferAmount, bool expectedResult)
        {
            TransferService transferService = new TransferService();
            bool actualResult = transferService.IsTransferAmount(transferAmount);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
