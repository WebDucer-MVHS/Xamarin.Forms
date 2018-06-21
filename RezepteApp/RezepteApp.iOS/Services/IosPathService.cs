using System;
using RezepteApp.Services;
using System.IO;
using Xamarin.Forms;
using RezepteApp.iOS.Services;

[assembly: Dependency(typeof(IosPathService))]
namespace RezepteApp.iOS.Services
{
    public class IosPathService : IPathService
    {
        public string GetDbPath(string dbName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, dbName);
        }
    }
}