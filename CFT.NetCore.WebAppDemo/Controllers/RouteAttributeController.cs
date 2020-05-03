using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CFT.NetCore.WebAppDemo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CFT.NetCore.WebAppDemo.Controllers
{
    [Route("api/Route")]
    [ApiController]
    public class RouteAttributeController : ControllerBase
    {
        [Route("GetOne")]
        public Task<RouteOneDto> GetOne(RouteOneDto routeOne)
        {
            return Task.FromResult<RouteOneDto>(routeOne);
        }
        [Route("GetTwo")]
        public Task<RouteTwoDto> GetTwo(RouteTwoDto routeTwo)
        {
            return Task.FromResult<RouteTwoDto>(routeTwo);
        }
        [Route("GetStr")]
        [HttpGet]
        public string GetStr(string str)
        {
            return str;
        }
    }
}