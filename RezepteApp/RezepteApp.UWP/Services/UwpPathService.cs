using RezepteApp.Services;
using RezepteApp.UWP.Services;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(UwpPathService))]
namespace RezepteApp.UWP.Services
{
    public class UwpPathService : IPathService
    {
        public string GetDbPath(string dbName)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path,
                dbName);
        }
    }
}
