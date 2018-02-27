using System;
using System.Collections.Generic;

namespace api.Services
{
    public class TransferService
    {
        public bool IsAccumulated(double accumulatedNumber)
        {
            if(accumulatedNumber == 0) {
                return true;
            }

            return false;
        }
    }
}
