using System;
using System.Collections.Generic;
using api.Models;

namespace api.Services
{
    public class TransferService
    {
        private TransferCondition transferCondition;
        public TransferOutputModel TransferMoney(TransferInputModel transferDataInput)
        {
            bool _valid = false;
            var _code = "400";
            var _message = "error";

            if(transferCondition.IsTransferAmount(Double.Parse(transferDataInput.transfer_amount))) {
                _valid = true;
            }

            if(_valid) {
                _code = "200";
                _message = "success";
            }

            HeaderModel header = new HeaderModel {
                code = _code,
                message = _message
            };

            TransferOutputDataModel body = new TransferOutputDataModel {
                origin_account_balance = "5000.00",
                origin_account_id = transferDataInput.origin_account_id,
                fee_amount = "35.00",
                transfer_amount = transferDataInput.transfer_amount.ToString()
            };

            TransferOutputModel transferOutputModel = new TransferOutputModel {
                header = header,
                body = body
            };

            return transferOutputModel;
        }
    }
}
