using System;
using System.Collections.Generic;

namespace api.Services
{
    public class TransferService
    {
        public bool IsAccumulated(int accumulatedNumber)
        {
            if(accumulatedNumber == 0) {
                return true;
            }

            return false;
        }
    }
}
