using CrossSync.Xamarin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Maui.Services
{
    public class ErrorService : IErrorService
    {
        

        public ErrorService()
        {
            
        }
        public void ShowError(string error)
        {
            Console.WriteLine(error);
        }
    }
}
