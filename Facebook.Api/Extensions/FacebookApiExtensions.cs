namespace Facebook.Api.Extensions
{
    using Facebook.Api.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Net.Http.Headers;

    public static class FacebookApiExtensions
    {
        public static IServiceCollection AddFacebookClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FacebookSettings>(configuration.GetSection("FacebookSettings"));

            services.AddHttpClient<IFacebookClient, FacebookClient>(options =>
            {
                options.BaseAddress = new Uri(configuration.GetSection("FacebookSettings").GetValue<string>("BaseUri"));
                options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddScoped<IFacebookService, FacebookService>();

            return services;
        }
    }
}
