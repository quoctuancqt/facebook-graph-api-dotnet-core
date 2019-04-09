namespace Facebook.Api.Services
{
    using Facebook.Api.Models;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class FacebookService : IFacebookService
    {
        private readonly IFacebookClient _facebookClient;

        public FacebookService(IFacebookClient facebookClient)
        {
            _facebookClient = facebookClient;
        }

        public async Task<object> StartLiveStreamAsync(string accessToken, string userId, object dto = null)
        {
            if (dto == null)
            {
                dto = new { Status = "LIVE_NOW", Title = "Live Today", Description = "This is the live video for today." };
            }

            var result = await _facebookClient.PostAsync(accessToken, $"{userId}/live_videos", dto);

            result.EnsureSuccessStatusCode();

            return await result.Content.ReadAsStringAsync();
        }

        public async Task<StreamInfo> GetLiveStreamByIdAsync(string accessToken, string streamId)
        {
            return await _facebookClient.GetAsync<StreamInfo>(accessToken, streamId, "fields=ingest_streams");
        }

        public async Task<object> StopLiveStreamAsync(string accessToken, string streamId)
        {
            var result = await _facebookClient.PostAsync(accessToken, streamId, new { end_live_video = true });

            result.EnsureSuccessStatusCode();

            return await result.Content.ReadAsStringAsync();
        }

        public async Task<object> DeleteLiveStreamAsync(string accessToken, string streamId)
        {
            var result = await _facebookClient.DeleteAsync(accessToken, streamId);

            result.EnsureSuccessStatusCode();

            return await result.Content.ReadAsAsync<bool>();
        }
    }
}