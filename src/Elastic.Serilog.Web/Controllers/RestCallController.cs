using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Elastic.Serilog.Web.Controllers
{
    public class RestCallController : Controller
    {
        private readonly ILogger<RestCallController> _logger;

        public RestCallController(ILogger<RestCallController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("RestCall controller executed at {date}", DateTime.UtcNow);

            try
            {
                using (var httpClient = new HttpClient { Timeout = TimeSpan.FromMilliseconds(100) })
                {
                    using (var response = await httpClient.GetAsync("http://localhost:1234/some-invalid-url"))
                    {
                        response.EnsureSuccessStatusCode();
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,"HttpClient get request failed");
                throw;
            }

            return View();
        }
    }
}