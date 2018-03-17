using System;
using System.Collections.Generic;
using api.Models;

namespace api.Services
{
    public class TransferService
    {
        public TransferOutputModel TransferMoney(TransferInputModel transferDataInput)
        {

            TransferCondition transferCondition = new TransferCondition();
            if(transferCondition.IsAccumulated(transferDataInput.origin_account_daily_accumulated_transfer) == false) {
                return _JsonOutput(new HeaderModel {
                    code = "400-01",
                    message = "Your accumulated transfer over 100,000THB per day"
                }, new TransferOutputDataModel());
            }

            if(transferCondition.IsTransferAmount(transferDataInput.transfer_amount) == false) {
                return _JsonOutput(new HeaderModel {
                    code = "400-02",
                    message = "Your transfer amount can't over 20,000THB"
                }, new TransferOutputDataModel());
            }

            double fee = transferCondition.IsSameBank(transferDataInput.origin_bank, transferDataInput.destination_bank);
            if(fee == 0) {
                fee = transferCondition.IsSameArea(transferDataInput.origin_bank_area, transferDataInput.destination_bank_area);
            }

            double transferAmountWithFee = transferDataInput.transfer_amount + fee;

            if(transferCondition.IsTotalTransferOverAccumulated(transferAmountWithFee, transferDataInput.origin_account_daily_accumulated_transfer)) {
                return _JsonOutput(new HeaderModel {
                    code = "400-03",
                    message = "Your transfer amount with fee over accumulated 100,000THB per day"
                }, new TransferOutputDataModel());
            }

            if(transferCondition.IsTotalTransferOverAccountBalance(transferAmountWithFee, transferDataInput.origin_account_balance)) {
                return _JsonOutput(new HeaderModel {
                    code = "400-04",
                    message = "Your balance not enought for transfer with deduct fee"
                }, new TransferOutputDataModel());
            }

            TransferOutputDataModel body = new TransferOutputDataModel {
                origin_account_balance = "5000.00",
                origin_account_id = transferDataInput.origin_account_id,
                fee_amount = "35.00",
                transfer_amount = transferDataInput.transfer_amount.ToString()
            };

            return _JsonOutput(new HeaderModel {
                    code = "200",
                    message = "Transfer completed"
                }, body);
        }

        private TransferOutputModel _JsonOutput(HeaderModel header, TransferOutputDataModel data) {

            header = new HeaderModel {
                code = header.code,
                message = header.message
            };

            TransferOutputDataModel body = new TransferOutputDataModel();

            TransferOutputModel transferOutputModel = new TransferOutputModel {
                header = header,
                body = data
            };
            
            return transferOutputModel;
        }
    
    }
}
