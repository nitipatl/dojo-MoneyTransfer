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

        public bool IsTransferFee(double transferFeeAmount)
        {
            if(transferFeeAmount > 0) {
                return true;
            }

            return false;
        }
    }
}
