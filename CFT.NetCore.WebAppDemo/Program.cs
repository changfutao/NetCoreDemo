using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CFT.NetCore.WebAppDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            //Host 宿主
            //作用: 启动、初始化应用程序，并管理其生命周期
            Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                //服务器的 内容根 ( content root ) 决定它将在哪里搜索内容文件
                //.UseContentRoot(Directory.GetCurrentDirectory())
                //为应用程序添加配置
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    //获取网站的目录
                    //var path = hostingContext.HostingEnvironment.ContentRootPath + "\\Configs\\";
                    var path = "Configs\\";
                    //博客配置文件
                    var blogPath = string.Concat(path, "blog.json");
                    //optional 是否必须  reloadOnChange 专门一个线程监控更新
                    config.AddJsonFile(path: blogPath, optional: true, reloadOnChange: true);

                    //开发环境和生产环境
                    var testPath = string.Concat(path, $"test.{hostingContext.HostingEnvironment.EnvironmentName}.json");
                    config.AddJsonFile(path: testPath, optional: true, reloadOnChange: true);
                });
               
    }
}
