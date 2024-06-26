﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossSync.Xamarin.Services
{
    public interface IHttpsClientHandlerService
    {
        public HttpMessageHandler GetPlatformMessageHandler();
        public HttpClient Client { get; }
        public string Token { get; }
    }
}
