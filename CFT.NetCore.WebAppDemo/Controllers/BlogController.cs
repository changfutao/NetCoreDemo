using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CFT.NetCore.WebAppDemo.Controllers
{
    [Route("api/Blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public BlogController(
            IConfiguration configuration
            )
        {
            this._configuration = configuration;
        }
        /// <summary>
        /// 获取博客基本信息
        /// </summary>
        /// <returns></returns>
        [Route("GetBlogInfo")]
        [HttpGet]
        public IActionResult GetBlogInfo()
        {
            string blogName = _configuration["blogName"].ToString();
            //测试环境配置
            string testName = _configuration["testName"].ToString();
            return new JsonResult(new { blogName,testName });
        }
    }
}