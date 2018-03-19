using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using other_bank_fake.api.Models;

namespace other_bank_fake.api.Controllers
{
    [Route("api/[controller]")]
    public class TransferController : Controller
    {

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "This simulate other bank api" };
        }

        [HttpPost]
        public JsonResult Post([FromBody] TransferInputModel transferDataInput)
        {
            var _code = "200";
            var _message = "success";

            if(transferDataInput.transfer_amount <= 0) {
                _code = "400";
                _message = "success";
            }
            
            TransferOutputModel TransferOutput = new TransferOutputModel
            {
                header = new HeaderModel
                {
                    status = _code,
                    message = _message
                },
                body = new BodyModel
                {
                    transfer_amount = transferDataInput.transfer_amount ,
                    datetime = DateTime.Now.ToString("yyyy-MM-ddThh:mm:sszzz")
                },
            };

            return Json(TransferOutput);
        }
    }
}
