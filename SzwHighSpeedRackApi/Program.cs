using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SzwHighSpeedRackApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseKestrel(option =>
                    //{
                    //    option.Listen(System.Net.IPAddress.Any, 5001, (lop) =>
                    //    {
                    //        lop.UseHttps(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"server.pfx"), "123456");
                    //        //参数为证书文件名称，证书密码
                    //    });
                    //});
                    webBuilder
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .UseUrls("http://*:5001");
                });
    }
}