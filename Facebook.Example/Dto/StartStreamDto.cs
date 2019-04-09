namespace FB.SDK.Dto
{
    using Facebook.Api;

    public class StartStreamDto
    {
        public string AccessToken { get; set; }
        public string UserId { get; set; }
        public StartLiveDataDto Data { get; set; }
    }
}
