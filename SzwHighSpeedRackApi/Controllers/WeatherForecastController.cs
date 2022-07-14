using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SzwHighSpeedRackApi.Controllers
{
    public class WeatherForecastController : RackBaseApiController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55)
            }).ToArray();
        }

        [AllowAnonymous]
        [HttpGet, Route("page2imgs")]
        public async Task<string> PageToImages([FromQuery] string url)
        {
            string fileName = $"Files/{Guid.NewGuid().ToString()}.png";
            string outputFile = $"{_hostEnvironment.ContentRootPath}/{fileName}";
            //using var browserFetcher = new BrowserFetcher();
            //await browserFetcher.DownloadAsync();
            await using var browser = await Puppeteer.LaunchAsync(
                new LaunchOptions
                {
                    Headless = true,
                    ExecutablePath = Path.Combine(_hostEnvironment.ContentRootPath, ".local-chromium", "Win64-970485", "chrome-win", "chrome.exe")
                });
            await using var page = await browser.NewPageAsync();
            await page.SetViewportAsync(new ViewPortOptions
            {
                Width = 1200,
                Height = 1500
            });
            await page.GoToAsync($"{url}");
            await page.ScreenshotAsync(outputFile);
            return $"{Request.Host}/{fileName}";
        }
    }
}