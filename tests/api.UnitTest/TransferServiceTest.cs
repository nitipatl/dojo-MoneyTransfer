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

        [Theory]
        [InlineData(35.00, true)]
        [InlineData(0.00, false)]
        public void When_TransferFee_Is_Not_0(double transferFee, bool expectedResult)
        {
            TransferService transferService = new TransferService();
            bool actualResult = transferService.IsTransferFee(transferFee);

            Assert.Equal(expectedResult, actualResult);
        }
        
        [Theory]
        [InlineData(535.00, 99465.00, true)]
        [InlineData(510.00, 10.00, true)]
        [InlineData(535.00, 99995.00, false)]
        public void When_TransferAmount_And_TransferFee_Is_Not_Over_Accumulated_In_Day(double transferAmountAndFee, double accumulatedNumber, bool expectedResult)
        {
            TransferService transferService = new TransferService();
            bool actualResult = transferService.IsTotalTransferNotOverAccumulated(transferAmountAndFee, accumulatedNumber);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("BKK001", "BKK001", 0)]
        [InlineData("BKK001", "NSW001", 10)]
        public void When_Transfer_Is_Same_Area(string originArea, string destinationArea, double expectedResult)
        {
            TransferService transferService = new TransferService();
            double actualResult = transferService.IsSameArea(originArea, destinationArea);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
