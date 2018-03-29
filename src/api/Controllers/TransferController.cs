using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class TransferController : Controller
    {
        private readonly TransferService _service;

        public TransferController(TransferService service)
        {
            _service = service;
        }

        [HttpPost]
        public JsonResult Post([FromBody] TransferInputModel transferDataInput)
        {
            var transferResult = _service.TransferMoney(transferDataInput);

            return Json(transferResult);
        }

        [HttpGet]
        public JsonResult Get()
        {
           return Html("Hello!!!#");
        }
        
    }
}
