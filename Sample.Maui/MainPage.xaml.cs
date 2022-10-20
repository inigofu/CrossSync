using CrossSync.Xamarin.DependencyInjection;
using CrossSync.Xamarin.Services;

namespace Sample.Maui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly IMobileSyncService<TodoList.Entities.Shared.TodoList> service;
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            syncdata();
        }
        private async void syncdata()
        {
            // Resolve the registrated sync service
            var synchronizationService = this.Handler.MauiContext.Services.GetServices<SynchronizationService>(); 
            // Starts the synchronization
            await synchronizationService.First().SyncAsync();
        }
    }
}