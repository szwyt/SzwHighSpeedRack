using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using MiniRazor;
using PuppeteerSharp;
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
            await page.SetViewportAsync(new ViewPortOptions
            {
                Width = 1024,
                Height = 768
            });
            var list = await System.IO.File.ReadAllLinesAsync($"{Path.Combine(AppContext.BaseDirectory, "siteurl.txt")}");
            await Task.Run(async () =>
            {
                foreach (var item in list)
                {
                    try
                    {
                        if (!item.IsURL()) continue;
                        string fileName = $"Files/{Guid.NewGuid()}.Png";
                        string outputFile = $"{_hostEnvironment.ContentRootPath}/{fileName}";
                        var result = await page.GoToAsync($"{item}", 3000);
                        if (result != null && result.Status == System.Net.HttpStatusCode.OK)
                        {
                            // 这里可查看后缀
                            await page.ScreenshotAsync($"{outputFile}", new ScreenshotOptions()
                            {
                                Type = ScreenshotType.Png,
                                Quality = 100,
                                FullPage = true,
                                OmitBackground = true
                            });
                        }
                        else
                        {
                            outputFile = "没有图片";
                        }
                        Console.WriteLine(outputFile);
                    }
                    catch { }
                }
            });

            return url;
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
    }
}