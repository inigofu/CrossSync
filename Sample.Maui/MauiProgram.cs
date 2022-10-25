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
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
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
            
            mauiAppBuilder.Services.AddSingleton<SyncConfiguration>(c => new SyncConfiguration { ApiBaseUrl = Constants.ApiBaseUrl, TombstoneUri = Constants.DeleteApiUri });
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.db").ToString();
            mauiAppBuilder.Services.AddSingleton<TodoListContext>(c=> new TodoListContext(dbPath));
            mauiAppBuilder.Services.AddSingleton<IConnectivityService, ConnectivityService>();
            mauiAppBuilder.Services.AddSingleton<IErrorService, ErrorService>();
            mauiAppBuilder.Services.AddSingleton<IUnitOfWork<TodoListContext>,UnitOfWork<TodoListContext>>();
            mauiAppBuilder.Services.AddSingleton<ISyncService,TodoListService>();
            mauiAppBuilder.Services.AddSingleton<SynchronizationService>();
            mauiAppBuilder.Services.AddSingleton<IHttpsClientHandlerService, HttpsClientHandlerService>();
            return mauiAppBuilder;
        }
        public static class Constants
        {
            public static string ApiBaseUrl => "https://10.0.2.2:7113/";
            public static string DeleteApiUri => "api/tombstone";
        }
    }
}