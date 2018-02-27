using System;
using System.Collections.Generic;

namespace api.Services
{
    public class TransferService
    {
        public bool IsAccumulated(double accumulatedNumber)
        {
            if((accumulatedNumber >= 0) && (accumulatedNumber < 100000)) {
                return true;
            }

            return false;
        }

        public bool IsTransferAmount(double transferAmount)
        {
            if((transferAmount >= 1) && (transferAmount <= 20000)) {
                return true;
            }

            return false;
        }

        public bool IsTransferFee(double transferFee)
        {
            if(transferFee > 0) {
                return true;
            }

            return false;
        }

        public bool IsTotalTransferNotOverAccumulated(double transferAmountAndFee, double accumulatedNumber)
        {
            double transferTotal = transferAmountAndFee + accumulatedNumber;
            if((transferTotal > 0) && (transferTotal <= 100000)) {
                return true;
            }

            return false;
        }
    }
}
