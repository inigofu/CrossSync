using CrossSync.Entity.Abstractions.EF.UnitOfWork;
using CrossSync.Infrastructure.Client.UnitOfWork;
using CrossSync.Xamarin.Services;
using Sample.Maui.Services;
using Sample.TodoList.Entities.Shared;

namespace Sample.Maui
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).RegisterAppServices();

            return builder.Build();
        }

        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<SynchronizationService>();
            mauiAppBuilder.Services.AddSingleton<SyncConfiguration>(c => new SyncConfiguration { ApiBaseUrl = Constants.ApiBaseUrl, TombstoneUri = Constants.DeleteApiUri });
            mauiAppBuilder.Services.AddSingleton<UnitOfWork<TodoListContext>>();
            return mauiAppBuilder;
        }
        public static class Constants
        {
            public static string ApiBaseUrl => "http://10.0.2.2:61448/";
            public static string DeleteApiUri => "api/tombstone";
        }
    }
}