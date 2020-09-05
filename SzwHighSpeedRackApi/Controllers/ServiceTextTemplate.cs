using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace SzwHighSpeedRackApi.Controllers
{
    public partial class TemplateController : ControllerBase
    {
        private JwtSettings _jwtSettings;
        ILogger<TemplateController> _logger;
        public TemplateController(JwtSettings config, ILogger<TemplateController> logger)
        {
            _jwtSettings = config;
            _logger = logger;
        }
    }
}