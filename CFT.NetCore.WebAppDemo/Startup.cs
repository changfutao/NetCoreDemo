using CFT.NetCore.WebAppDemo.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CFT.NetCore.WebAppDemo.Data;
using Microsoft.EntityFrameworkCore;

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
            //注入EFCore服务
            services.AddDbContext<EFContext>(options => 
            {
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            });

            //注入WebApi服务
            services.AddControllers();
        }

        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env,
            IConfiguration configuration
            )
        {
            //重点: 中间件的添加顺序将决定HTTP请求以及HTTP响应遍历它们的顺序
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region 中间件

            //自定义中间件
            app.UseMiddleware<HttpMethodCheckMiddleware>();

            #endregion

            //添加静态文件中间件
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
