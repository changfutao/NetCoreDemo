using CFT.NetCore.WebAppDemo.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CFT.NetCore.WebAppDemo.Data;
using Microsoft.EntityFrameworkCore;
using CFT.NetCore.WebAppDemo.Repository;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CFT.NetCore.WebAppDemo.Models;
using Microsoft.AspNetCore.Routing;
using CFT.NetCore.WebAppDemo.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CFT.NetCore.WebAppDemo
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            #region 依赖注入
            services.AddTransient<IOperationTransient, Operation>();
            services.AddScoped<IOperationScoped, Operation>();
            services.AddSingleton<IOperationSingleton, Operation>();
            #endregion

            services.AddSingleton<IHashFactory, HashFactory>();

            //注入EFCore服务
            services.AddDbContext<EFContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            });

            //注入Repository
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            //注入AutoMapper
            services.AddAutoMapper(typeof(Startup));

            //注入WebApi服务
            services.AddControllers(options => 
            {
                //添加缓存配置
                options.CacheProfiles.Add("Default", new CacheProfile()
                { 
                    Duration=60
                });
            });

            //注入MVC
            services.AddRazorPages();
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IConfiguration configuration,
            ILogger<Startup> logger
            )
        {
            //重点: 中间件的添加顺序将决定HTTP请求以及HTTP响应遍历它们的顺序
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region 中间件
            app.Use(async (context, next) =>
            {
                string authorId = context.Request.Query["authorId"].ToString();
                if (!string.IsNullOrEmpty(authorId))
                {
                    logger.LogInformation("进入中间件1");
                    logger.LogInformation($"获取authorId为{authorId}");
                }
                await next();
                logger.LogInformation("退出中间件1");
            });
            //Map与MapWhen区别 
            //Map只能根据指定的请求路径的匹配来分支请求
            //Map 方法不会回到原来的管道上,所以不会执行后面的中间件
            //MapWhen功能更强大，并允许根据与当前对象一起运行的指定谓词的结果来分支请求。 到目前为止HttpContext包含有关HTTP请求的所有信息，MapWhen允许您使用非常特定的条件来分支请求管道。
            app.Map(new PathString("/path1"), builder =>
            {
                builder.Use(async (context, next) =>
                {
                    logger.LogInformation("进入Map中间件");
                    await next();
                    logger.LogInformation("退出Map中间件");
                });
            });
            //当返回true的时候,才执行里面中间件 MapWhen方法不会回到原来的管道上,所以不会执行后面的中间件
            app.MapWhen(context =>
            {
                return context.Request.Path.StartsWithSegments("/SomePathMatch");
            }, builder =>
            {
                builder.Use(async (context, next) =>
                {
                    logger.LogInformation("进入MapWhen中间件");
                    await next();
                    logger.LogInformation("退出MapWhen中间件");
                });
            });
            //UseWhen方法 由它创建的新分支在执行完以后会继续回到原来的管道上
            app.UseWhen(context => context.Request.Path.Value == "/maptest", builder =>
            {
                builder.Use(async (context, next) =>
                {
                    logger.LogInformation("进入UseWhen中间件");
                    await next();
                    logger.LogInformation("退出UseWhen中间件");
                });
            });
            //终端中间件,后面的中间件不会执行
            //app.Run(async context => 
            //{
            //    logger.LogInformation("进入Run中间件");
            //    await Task.CompletedTask;
            //});

            //自定义中间件
            app.UseMiddleware<HttpMethodCheckMiddleware>();

            #endregion

            //添加静态文件中间件
            app.UseStaticFiles();

            #region 路由
            ////创建路由处理器
            //var trackPackageRouteHandler = new RouteHandler(context =>
            //{
            //    var routeValues = context.GetRouteData().Values;
            //    return context.Response.WriteAsync($"Hello! Route values:{string.Join(", ", routeValues)}");
            //});

            //var routeBuilder = new RouteBuilder(app, trackPackageRouteHandler);

            //routeBuilder.MapRoute("Track Package Route", "package/{operation}/{id:int}");
            ////MapGet 仅匹配Get方法的请求
            //routeBuilder.MapGet("hello/{name}", context =>
            //{
            //    var name = context.GetRouteValue("name");
            //    return context.Response.WriteAsync($"Hi,{name}");
            //});

            //var routes = routeBuilder.Build();
            //app.UseRouter(routes); 
            #endregion

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();

                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
