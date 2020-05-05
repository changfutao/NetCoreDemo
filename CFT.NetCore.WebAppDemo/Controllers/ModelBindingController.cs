using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CFT.NetCore.WebAppDemo.Controllers
{
    [Route("api/ModelBinding")]
    [ApiController]
    public class ModelBindingController : ControllerBase
    {
        [Route("GetInfo")]
        [HttpGet]
        public IActionResult GetInfo([FromQuery]string name, [FromHeader]string clientId)
        {
            return new JsonResult(new { name, clientId });
        }
    }
}