using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using System.Net.Http.Headers;
using MauiApp1.Services;
using MauiApp1.Viewmodels;
using MauiApp1.Views;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            var httpClient = new HttpClient { BaseAddress = new Uri($"https://www.themealdb.com/api/json/v1/1/") };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            builder.Services.AddSingleton<HttpClient>(httpClient);
            builder.Services.AddSingleton<IApiService, ApiService>();
            builder.Services.AddSingleton<MainPageViewmodel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<RecipeListViewmodel>();
            builder.Services.AddTransient<RecipeList>();
            builder.Services.AddTransient<RecipeDetailViewmodel>();
            builder.Services.AddTransient<RecipeDetail>();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
