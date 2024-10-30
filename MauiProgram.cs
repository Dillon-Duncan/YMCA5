using Microsoft.Extensions.Logging;
using YMCA3.Components.Pages;
using YmcaApiClient.IoC;

namespace YMCA3
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddYmcaApiClientService(x => x.ApiBaseAddress = "http://localhost:5013");
            builder.Services.AddTransient<Admin>();
            builder.Services.AddTransient<BulletinBoard>();
            builder.Services.AddTransient<Calendar>();
            builder.Services.AddTransient<Chats>();
            builder.Services.AddTransient<Chatting>();
            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<News>();
            builder.Services.AddTransient<Register>();
            builder.Services.AddTransient<UserAccount>();
            builder.Services.AddTransient<Volunteer>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}