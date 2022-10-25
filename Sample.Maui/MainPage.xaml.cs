using CrossSync.Xamarin.DependencyInjection;
using CrossSync.Xamarin.Services;
using Sample.Maui.Services;
using System.Collections.ObjectModel;

namespace Sample.Maui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        
        public ObservableCollection<TodoList.Entities.Shared.TodoList> Todos { get; set; }
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
            var service =(TodoListService)this.Handler.MauiContext.Services.GetServices<ISyncService>().First();
            var todos = await service.GetAllAsync();
            Todos = new ObservableCollection<TodoList.Entities.Shared.TodoList>( todos);
            this.lista.ItemsSource=Todos;
            
        }
    }
}