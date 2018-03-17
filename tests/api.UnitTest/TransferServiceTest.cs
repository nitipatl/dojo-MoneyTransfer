using System;
using Xunit;
using api.Services;
using api.Models;

namespace api.UnitTest
{
    public class TransferServiceTest
    {
        
        [Theory]
        [InlineData(500.00)]
        [InlineData(20000.00)]
        public void When_TransferAmount_Between_1_And_20000_Should_Be_Can_Transfer(double transferAmount)
        {
            var transferInput = new TransferInputModel {
                transfer_amount = transferAmount,
                destination_account_id = "7581233661",
                destination_bank = "KBANK",
                destination_bank_area = "BKK01",
                origin_account_id = "6320445476",
                origin_account_balance = 50000,
                origin_bank = "KBANK",
                origin_bank_area = "BKK01",
                origin_account_daily_accumulated_transfer = 0
            };

            TransferService transferService = new TransferService();
            TransferOutputModel actualResult = transferService.TransferMoney(transferInput);

            Assert.Equal("200", actualResult.header.code);
            Assert.Equal(transferAmount.ToString(), actualResult.body.transfer_amount);
        }
        
        [Theory]
        [InlineData(0.00)]
        [InlineData(20001.00)]
        public void When_TransferAmount_Not_Between_1_And_20000_Should_Be_Cant_Transfer(double transferAmount)
        {
            var transferInput = new TransferInputModel {
                transfer_amount = transferAmount,
                destination_account_id = "7581233661",
                destination_bank = "KBANK",
                destination_bank_area = "BKK01",
                origin_account_id = "6320445476",
                origin_account_balance = 50000,
                origin_bank = "KBANK",
                origin_bank_area = "BKK01",
                origin_account_daily_accumulated_transfer = 0
            };

            TransferService transferService = new TransferService();
            TransferOutputModel actualResult = transferService.TransferMoney(transferInput);

            Assert.Equal("400-02", actualResult.header.code);
        }

        [Theory]
        [InlineData(100.00)]
        [InlineData(5000.00)]
        public void When_Accumulated_Between_0_And_100000_Should_Be_True(double transferAmount)
        {

            var transferInput = new TransferInputModel {
                transfer_amount = transferAmount,
                destination_account_id = "7581233661",
                destination_bank = "KBANK",
                destination_bank_area = "BKK01",
                origin_account_id = "6320445476",
                origin_account_balance = 50000,
                origin_bank = "KBANK",
                origin_bank_area = "BKK01",
                origin_account_daily_accumulated_transfer = 95000
            };

            TransferService transferService = new TransferService();
            TransferOutputModel actualResult = transferService.TransferMoney(transferInput);

            Assert.Equal("200", actualResult.header.code);
        }
        
        [Theory]
        [InlineData(10000.00)]
        public void When_Accumulated_Between_0_And_100000_Should_Be_False(double transferAmount)
        {

            var transferInput = new TransferInputModel {
                transfer_amount = transferAmount,
                destination_account_id = "7581233661",
                destination_bank = "KBANK",
                destination_bank_area = "BKK01",
                origin_account_id = "6320445476",
                origin_account_balance = 50000,
                origin_bank = "KBANK",
                origin_bank_area = "BKK01",
                origin_account_daily_accumulated_transfer = 95000
            };

            TransferService transferService = new TransferService();
            TransferOutputModel actualResult = transferService.TransferMoney(transferInput);

            Assert.Equal("400-03", actualResult.header.code);
        }


        [Fact]
        public void When_Accumulated_More_Than_100000_Should_Be_False()
        {

            var transferInput = new TransferInputModel {
                transfer_amount = 100,
                destination_account_id = "7581233661",
                destination_bank = "KBANK",
                destination_bank_area = "BKK01",
                origin_account_id = "6320445476",
                origin_account_balance = 50000,
                origin_bank = "KBANK",
                origin_bank_area = "BKK01",
                origin_account_daily_accumulated_transfer = 100000
            };

            TransferService transferService = new TransferService();
            TransferOutputModel actualResult = transferService.TransferMoney(transferInput);

            Assert.Equal("400-01", actualResult.header.code);
        }

        [Theory]
        [InlineData(5001.00)]
        [InlineData(10000.00)]
        public void When_TransferAmount_Without_Fee_More_Than_Account_Balance_Should_Be_Cant_Transfer(double transferAmount)
        {
            var transferInput = new TransferInputModel {
                transfer_amount = transferAmount,
                destination_account_id = "7581233661",
                destination_bank = "KBANK",
                destination_bank_area = "BKK01",
                origin_account_id = "6320445476",
                origin_account_balance = 5000,
                origin_bank = "KBANK",
                origin_bank_area = "BKK01",
                origin_account_daily_accumulated_transfer = 0
            };

            TransferService transferService = new TransferService();
            TransferOutputModel actualResult = transferService.TransferMoney(transferInput);

            Assert.Equal("400-04", actualResult.header.code);
        }


        [Fact]
        public void When_TransferAmount_With_Fee_More_Than_Account_Balance_Should_Be_Cant_Transfer()
        {
            var transferInput = new TransferInputModel {
                transfer_amount = 5000,
                destination_account_id = "7581233661",
                destination_bank = "SCB",
                destination_bank_area = "",
                origin_account_id = "6320445476",
                origin_account_balance = 5000,
                origin_bank = "KBANK",
                origin_bank_area = "BKK01",
                origin_account_daily_accumulated_transfer = 0
            };

            TransferService transferService = new TransferService();
            TransferOutputModel actualResult = transferService.TransferMoney(transferInput);

            Assert.Equal("400-04", actualResult.header.code);
        }

        [Fact]
        public void When_TransferAmount_Same_Bank_Same_Area_Should_Be_Fee_0THB()
        {
            var transferInput = new TransferInputModel {
                transfer_amount = 100,
                destination_account_id = "7581233661",
                destination_bank = "KBANK",
                destination_bank_area = "BKK01",
                origin_account_id = "6320445476",
                origin_account_balance = 50000,
                origin_bank = "KBANK",
                origin_bank_area = "BKK01",
                origin_account_daily_accumulated_transfer = 0
            };

            TransferService transferService = new TransferService();
            TransferOutputModel actualResult = transferService.TransferMoney(transferInput);

            Assert.Equal("200", actualResult.header.code);
            Assert.Equal("0", actualResult.body.fee_amount);
        }

        [Fact]
        public void When_TransferAmount_Same_Bank_Difference_Area_Should_Be_Fee_10THB()
        {
            var transferInput = new TransferInputModel {
                transfer_amount = 100,
                destination_account_id = "7581233661",
                destination_bank = "KBANK",
                destination_bank_area = "BKK02",
                origin_account_id = "6320445476",
                origin_account_balance = 50000,
                origin_bank = "KBANK",
                origin_bank_area = "BKK01",
                origin_account_daily_accumulated_transfer = 0
            };

            TransferService transferService = new TransferService();
            TransferOutputModel actualResult = transferService.TransferMoney(transferInput);

            Assert.Equal("200", actualResult.header.code);
            Assert.Equal("10", actualResult.body.fee_amount);
        }

        [Fact]
        public void When_TransferAmount_Difference_Bank__Should_Be_Fee_35THB()
        {
            var transferInput = new TransferInputModel {
                transfer_amount = 100,
                destination_account_id = "7581233661",
                destination_bank = "SCB",
                destination_bank_area = "",
                origin_account_id = "6320445476",
                origin_account_balance = 50000,
                origin_bank = "KBANK",
                origin_bank_area = "BKK01",
                origin_account_daily_accumulated_transfer = 0
            };

            TransferService transferService = new TransferService();
            TransferOutputModel actualResult = transferService.TransferMoney(transferInput);

            Assert.Equal("200", actualResult.header.code);
            Assert.Equal("35", actualResult.body.fee_amount);
        }
    }
}
