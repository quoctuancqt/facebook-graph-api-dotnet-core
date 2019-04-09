namespace FB.SDK
{
    using Facebook.Api;
    using Facebook.Api.Services;
    using FB.SDK.Dto;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class FacebookController : ControllerBase
    {
        private readonly IFacebookService _facebookService;
        private readonly IOptions<FacebookSettings> _options;

        public FacebookController(IFacebookService facebookService, IOptions<FacebookSettings> options)
        {
            _facebookService = facebookService;
            _options = options;
        }

        [HttpPost("start-stream")]
        public async Task<IActionResult> StartStreamAsync([FromBody] StartStreamDto dto)
        {
            var result = await _facebookService.StartLiveStreamAsync(dto.AccessToken, dto.UserId, dto.Data);

            return Ok(result);
        }

        [HttpPost("stop-stream")]
        public async Task<IActionResult> StopStreamAsync([FromBody] StopStreamDto dto)
        {
            var result = await _facebookService.StopLiveStreamAsync(dto.AccessToken, dto.StreamId);

            return Ok(result);
        }

        [HttpDelete("delete-stream")]
        public async Task<IActionResult> DeleteStreamAsync([FromBody] StopStreamDto dto)
        {
            var result = await _facebookService.DeleteLiveStreamAsync(dto.AccessToken, dto.StreamId);

            return Ok(result);
        }

        [HttpGet("{streamId}")]
        public async Task<IActionResult> GetStreamAsync(string accessToken, string streamId)
        {
            var result = await _facebookService.GetLiveStreamByIdAsync(accessToken, streamId);

            return Ok(result);
        }

        public IActionResult Test()
        {
            return Ok(_options.Value);
        }
    }
}
