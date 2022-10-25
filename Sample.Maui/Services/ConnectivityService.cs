using CrossSync.Xamarin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Maui.Services
{
    public class ConnectivityService : IConnectivityService
    {
        private readonly IConnectivity connectivity;

        public ConnectivityService()
        {
            
        }

        public bool IsConnected => true;

        public Task<bool> IsRemoteReachable(string url)
        {
            return System.Threading.Tasks.Task.FromResult(true);
        }
    }
}
