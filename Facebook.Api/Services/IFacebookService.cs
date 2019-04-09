namespace Facebook.Api.Services
{
    using Facebook.Api.Models;
    using System.Threading.Tasks;

    public interface IFacebookService
    {
        Task<object> StartLiveStreamAsync(string accessToken, string userId, object dto = null);
        Task<StreamInfo> GetLiveStreamByIdAsync(string accessToken, string streamId);
        Task<object> StopLiveStreamAsync(string accessToken, string streamId);
        Task<object> DeleteLiveStreamAsync(string accessToken, string streamId);
    }
}
