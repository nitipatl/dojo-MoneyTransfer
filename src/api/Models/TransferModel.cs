using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class TransferInputModel
    {
        public double transfer_amount { get; set; }
        public string destination_bank { get; set; }
        public string destination_bank_area { get; set; }
        public string destination_account_id { get; set; }
        public string origin_account_id { get; set; }
        public string origin_bank { get; set; }
        public string origin_bank_area { get; set; }
        public double origin_account_balance { get; set; }
        public double origin_account_daily_accumulated_transfer { get; set; }

    }

    public class HeaderModel
    {
        public string code { get; set; }
        public string message { get; set; }
    }

    public class TransferOutputDataModel
    {
        public string transfer_amount { get; set; }
        public string fee_amount { get; set; }
        public string origin_account_balance { get; set; }
        public string origin_account_id { get; set; }
    }

    public class TransferOutputModel
    {
        public HeaderModel header { get; set; }
        public TransferOutputDataModel body { get; set; }
    }

}
