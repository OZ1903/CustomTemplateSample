using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace YourCompany.MicroserviceTemplate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyController : ControllerBase
    {

        private readonly ILogger<MyController> _logger;
        private readonly TelemetryClient _telemetryClient;

        public MyController(ILogger<MyController> logger, TelemetryClient telemetryClient)
        {
            _logger = logger;
            _telemetryClient = telemetryClient;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Get called!");
            _telemetryClient.TrackEvent("Sample event if you want", null, null);

            return Ok("Get successful!");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Created("Sample uri", "Post successful!");
        }
    }
}
