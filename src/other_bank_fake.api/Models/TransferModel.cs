using System.Collections.Generic;

namespace other_bank_fake.api.Models
{
    public class TransferInputModel
    {
        public double transfer_amount { get; set; }
    }

    public class HeaderModel
    {
        public string status { get; set; }
        public string message { get; set; }
    }

    public class BodyModel
    {
        public double transfer_amount { get; set; }
        public string datetime { get; set; }
    }

    public class TransferOutputModel
    {
        public HeaderModel header { get; set; }
        public BodyModel body { get; set; }
    }
}