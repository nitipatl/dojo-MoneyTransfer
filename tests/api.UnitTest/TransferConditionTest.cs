using System;
using Xunit;
using api.Services;

namespace api.UnitTest
{
    public class TransferConditionTest
    {
        [Theory]
        [InlineData(0.00, true)]
        [InlineData(500.00, true)]
        [InlineData(100000.00, false)]
        public void When_Accumulated_Between_0_And_100000(double accumulatedNumber, bool expectedResult)
        {
            TransferCondition transferCondition = new TransferCondition();
            bool actualResult = transferCondition.IsAccumulated(accumulatedNumber);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(0.00, false)]
        [InlineData(500.00, true)]
        [InlineData(20000.00, true)]
        [InlineData(20001.00, false)]
        public void When_TransferAmount_Between_1_And_20000(double transferAmount, bool expectedResult)
        {
            TransferCondition transferCondition = new TransferCondition();
            bool actualResult = transferCondition.IsTransferAmount(transferAmount);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(35.00, true)]
        [InlineData(0.00, false)]
        public void When_TransferFee_Is_Not_0(double transferFee, bool expectedResult)
        {
            TransferCondition transferCondition = new TransferCondition();
            bool actualResult = transferCondition.IsTransferFee(transferFee);

            Assert.Equal(expectedResult, actualResult);
        }
        
        [Theory]
        [InlineData(535.00, 99465.00, true)]
        [InlineData(510.00, 10.00, true)]
        [InlineData(535.00, 99995.00, false)]
        public void When_TransferAmount_And_TransferFee_Is_Not_Over_Accumulated_In_Day(double transferAmountAndFee, double accumulatedNumber, bool expectedResult)
        {
            TransferCondition transferCondition = new TransferCondition();
            bool actualResult = transferCondition.IsTotalTransferOverAccumulated(transferAmountAndFee, accumulatedNumber);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("BKK001", "BKK001", 0.00)]
        [InlineData("BKK001", "NSW001", 10.00)]
        public void When_Transfer_Is_Same_Area(string originArea, string destinationArea, double expectedResult)
        {
            TransferCondition transferCondition = new TransferCondition();
            double actualResult = transferCondition.IsSameArea(originArea, destinationArea);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("SCB", "SCB", 0.00)]
        [InlineData("SCB", "KBANK", 35.00)]
        public void When_Transfer_Is_Same_Bank(string originBank, string destinationBank, double expectedResult)
        {
            TransferCondition transferCondition = new TransferCondition();
            double actualResult = transferCondition.IsSameBank(originBank, destinationBank);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(535.00, 5000.00, true)]
        [InlineData(5000.00, 5000.00, true)]
        [InlineData(5535.00, 5000.00, false)]
        public void When_TransferAmount_And_TransferFee_Is_Not_Over_Account_Balance(double transferAmountAndFee, double accountBalance, bool expectedResult)
        {
            TransferCondition transferCondition = new TransferCondition();
            bool actualResult = transferCondition.IsTotalTransferOverAccountBalance(transferAmountAndFee, accountBalance);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
