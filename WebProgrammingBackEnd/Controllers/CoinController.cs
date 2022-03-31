using Microsoft.AspNetCore.Mvc;

namespace WebProgrammingBackEnd.Controllers
{
    [Route("api/coins")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        private readonly string[] _options;
        private readonly IConfiguration _config;
        public CoinController(IConfiguration config)
        {
            _config = config;
            _options = new[] { "3h", "24h", "7d", "30d", "3m", "1y", "3y", "5y" };
        }
        [HttpGet("stats")]
        public async Task<IActionResult> GetCoins(string timePeriod = "3h")
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_config["CoinRankingSettings:URI"]}?timePeriod={timePeriod}"),
                Headers =
                {
                    { "X-RapidAPI-Host", _config["CoinRankingSettings:X-RapidAPI-Host"] },
                    { "X-RapidAPI-Key", _config["CoinRankingSettings:X-RapidAPI-Key"] },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return new JsonResult(body);
            }
        }

        [HttpGet("options")]
        public IActionResult GetOptions()
        {
            return new JsonResult(_options);
        }
    }
}
