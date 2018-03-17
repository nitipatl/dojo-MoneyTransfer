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
    }
}
