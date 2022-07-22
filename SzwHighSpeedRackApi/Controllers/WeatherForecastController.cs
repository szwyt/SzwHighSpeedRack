using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using MiniRazor;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zhulong.Library.Common.Extensions;

namespace SzwHighSpeedRackApi.Controllers
{
    public class WeatherForecastController : RackBaseApiController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private IHttpClientFactory _httpClientFactory;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWebHostEnvironment hostEnvironment, IHttpClientFactory httpclient)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
            _httpClientFactory = httpclient;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task Get()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.GetAsync("http://www.nhcet.com/result/resultList.jsp?sign=result#");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

            }
        }

        [AllowAnonymous]
        [HttpGet, Route("Url2imgs")]
        public async Task<string> Url2imgs([FromQuery] string url)
        {
            string chromePath = Path.Combine(_hostEnvironment.ContentRootPath, ".local-chromium", "Win64-970485", "chrome-win");
            // 如果不存在chrome就下载一个
            if (!Directory.Exists(chromePath))
            {
                using var browserFetcher = new BrowserFetcher();
                await browserFetcher.DownloadAsync();
            }

            await using var browser = await Puppeteer.LaunchAsync(
                new LaunchOptions
                {
                    Headless = true,
                    ExecutablePath = Path.Combine(chromePath, "chrome.exe")
                });
            await using var page = await browser.NewPageAsync();
            var width = await page.WaitForFunctionAsync("() => window.innerWidth");
            var innerHeight = await page.WaitForFunctionAsync("() => window.innerHeight");
            await page.SetViewportAsync(new ViewPortOptions
            {
                Width = 1920,
                Height = 1080,
            });
            var list = await System.IO.File.ReadAllLinesAsync($"{Path.Combine(AppContext.BaseDirectory, "siteurl.txt")}");
            await Task.Run(async () =>
            {
                for (int i = 2523; i < list.Count(); i++)
                {

                    try
                    {
                        var item = list[i];
                        if (!item.IsURL()) continue;

                        var result = await page.GoToAsync($"{item}");
                        await page.WaitForTimeoutAsync(3000);
                        int j = i + 1;
                        if (result != null && result.Status == System.Net.HttpStatusCode.OK)
                        {
                            string fileName = $"Files/{j}.Png";
                            string outputFile = $"{_hostEnvironment.ContentRootPath}/{fileName}";
                            ////将页面保存为图片
                            //using (var stream = await page.ScreenshotStreamAsync(new ScreenshotOptions
                            //{
                            //    //Clip = new PuppeteerSharp.Media.Clip
                            //    //{
                            //    //    X = 0,
                            //    //    Y = 0,
                            //    //    Width = await width1.JsonValueAsync<decimal>(),
                            //    //    Height = await innerHeight1.JsonValueAsync<decimal>(),
                            //    //    Scale = 1
                            //    //}
                            //    FullPage = true,
                            //}))
                            //{

                            //    byte[] srcBuf = new byte[stream.Length];
                            //    stream.Read(srcBuf, 0, srcBuf.Length);
                            //    stream.Seek(0, SeekOrigin.Begin);
                            //    using (FileStream fs = new FileStream($"{outputFile}", FileMode.Create, FileAccess.Write))
                            //    {
                            //        fs.Write(srcBuf, 0, srcBuf.Length);
                            //    }
                            //}

                            var buffer = await result.BufferAsync();
                            if (buffer.Length > 10 * 1024)
                            {
                                await page.ScreenshotAsync($"{outputFile}", new ScreenshotOptions()
                                {
                                    Type = ScreenshotType.Png,
                                    FullPage = true,
                                });
                                Console.WriteLine($"{j}----------------->" + outputFile);
                            }
                            else
                                Console.WriteLine($"{j}----------------->" + "buffer is big data");
                        }
                        else
                        {
                            Console.WriteLine($"{j}----------------->" + "没有生成图片");
                        }
                    }
                    catch
                    {
                        var k = i + 1;
                        Console.WriteLine($"{k}----------------->" + "error");
                    }
                }
            });

            return url;
        }

        [AllowAnonymous]
        [HttpGet, Route("Url2img")]
        public async Task<string> Url2img([FromQuery] string url)
        {
            string chromePath = Path.Combine(_hostEnvironment.ContentRootPath, ".local-chromium", "Win64-970485", "chrome-win");
            string fileName = $"Files/{Guid.NewGuid()}.Png";
            string outputFile = $"{_hostEnvironment.ContentRootPath}/{fileName}";
            // 如果不存在chrome就下载一个
            if (!Directory.Exists(chromePath))
            {
                using var browserFetcher = new BrowserFetcher();
                await browserFetcher.DownloadAsync();
            }

            await using var browser = await Puppeteer.LaunchAsync(
                new LaunchOptions
                {
                    Headless = true,
                    ExecutablePath = Path.Combine(chromePath, "chrome.exe")
                });
            await using var page = await browser.NewPageAsync();
            await page.SetViewportAsync(new ViewPortOptions
            {
                Width = 1920,
                Height = 1080,
            });

            var result = await page.GoToAsync(url);
            await page.WaitForTimeoutAsync(3000);
            var buffer = await result.BufferAsync();
            await page.ScreenshotAsync($"{outputFile}", new ScreenshotOptions()
            {
                Type = ScreenshotType.Png,
                FullPage = true,
            });
            return $"{Request.Host}/{fileName}";
        }

        [AllowAnonymous]
        [HttpGet, Route("Html2imgs")]
        public async Task<string> Html2imgs([FromQuery] string html)
        {
            string fileName = $"Files/{Guid.NewGuid()}.png";
            string outputFile = $"{_hostEnvironment.ContentRootPath}/{fileName}";
            string chromePath = Path.Combine(_hostEnvironment.ContentRootPath, ".local-chromium", "Win64-970485", "chrome-win");
            // 如果不存在chrome就下载一个
            if (!Directory.Exists(chromePath))
            {
                using var browserFetcher = new BrowserFetcher();
                await browserFetcher.DownloadAsync();
            }

            await using var browser = await Puppeteer.LaunchAsync(
                new LaunchOptions
                {
                    Headless = true,
                    ExecutablePath = Path.Combine(chromePath, "chrome.exe")
                });
            await using var page = await browser.NewPageAsync();

            StringBuilder sb = new StringBuilder();
            await using TextWriter writer = new StringWriter(sb);
            string templateSource = await System.IO.File.ReadAllTextAsync($"{Path.Combine(AppContext.BaseDirectory, "Templates", "TemplateFoo.cshtml")}");
            TemplateDescriptor descriptor = Razor.Compile(templateSource);
            await descriptor.RenderAsync(writer, new List<string> { "John", "小史" });
            html = sb.ToString();
            await page.SetContentAsync(html);
            // 这里可查看后缀
            await page.ScreenshotAsync($"{outputFile}", new ScreenshotOptions()
            {
                Type = ScreenshotType.Png,
                FullPage = true,
                OmitBackground = true
            });
            return $"{Request.Host}/{fileName}";
        }

        [AllowAnonymous]
        [HttpGet, Route("Url2Pdf")]
        public async Task<string> Url2Pdf([FromQuery] string url)
        {
            string chromePath = Path.Combine(_hostEnvironment.ContentRootPath, ".local-chromium", "Win64-970485", "chrome-win");
            string fileName = $"Files/{Guid.NewGuid()}.pdf";
            string outputFile = $"{_hostEnvironment.ContentRootPath}/{fileName}";
            // 如果不存在chrome就下载一个
            if (!Directory.Exists(chromePath))
            {
                using var browserFetcher = new BrowserFetcher();
                await browserFetcher.DownloadAsync();
            }

            await using var browser = await Puppeteer.LaunchAsync(
                new LaunchOptions
                {
                    Headless = true,
                    ExecutablePath = Path.Combine(chromePath, "chrome.exe")
                });
            await using var page = await browser.NewPageAsync();
            await page.SetViewportAsync(new ViewPortOptions
            {
                Width = 1920,
                Height = 1080,
            });

            var result = await page.GoToAsync(url);
            await page.WaitForTimeoutAsync(3000);
            PdfOptions pdfOptions = new PdfOptions();
            pdfOptions.DisplayHeaderFooter = false; //是否显示页眉页脚
            pdfOptions.FooterTemplate = "";   //页脚文本
            pdfOptions.Format = new PaperFormat(11.27m, 30m);  //pdf纸张格式 英寸为单位 
            pdfOptions.Format = PaperFormat.A4;
            pdfOptions.PrintBackground = true; // false pdf文件为灰白色，一些背景色也显示出来； true 页面为彩色
            pdfOptions.HeaderTemplate = "";   //页眉文本
            pdfOptions.Landscape = false;     //纸张方向 false-垂直 true-水平
            pdfOptions.MarginOptions = new MarginOptions() { Bottom = "0px", Left = "0px", Right = "0px", Top = "0px" }; //纸张边距，需要设置带单位的值，默认值是None
            pdfOptions.Scale = 1m;            //PDF缩放，从0-1
            await page.PdfAsync(outputFile, pdfOptions);

            return $"{Request.Host}/{fileName}";
        }
    }
}