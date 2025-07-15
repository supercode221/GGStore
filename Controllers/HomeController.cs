using Microsoft.AspNetCore.Mvc;
using BLL.Services.Interfaces;
using _HACore.Logs.Models;
using _HACore.Logs.Interfaces;
using _HACore.Logs.Implements;

namespace GGStore.Controllers
{
    public class HomeController : Controller
    {

        private readonly HACoreILogger _logger;
        private readonly DatabaseLogger _dbLogger;
        private readonly SystemLogger _systemLogger;
        private readonly UserActivityLogger _userLogger;
        private readonly IProductService _productService;
        private readonly IConfiguration _configuration;

        public HomeController(HACoreILogger logger, IProductService productService, IConfiguration configuration)
        {
            var config = new HACoreLoggingConfig
            {
                MinimumLevel = HACoreLogLevel.Debug,
                EnableConsoleOutput = true,
                EnableFileOutput = true,
                SeparateFilesByCategory = true,
                LogDirectory = "GGStoreLogs"
            };

            HACOreLoggerFactory.Initialize(config);
            _logger = HACOreLoggerFactory.Instance;
            _dbLogger = new DatabaseLogger(_logger);
            _systemLogger = new SystemLogger(_logger);
            _userLogger = new UserActivityLogger(_logger);

            _productService = productService;
            _configuration = configuration;
        }

        [HttpGet("/")]
        public IActionResult Homepage()
        {
            return View();
        }
    }
}
