using RezepteApp.Droid.Services;
using RezepteApp.Services;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidPathService))]
namespace RezepteApp.Droid.Services
{
    public class AndroidPathService : IPathService
    {
        public string GetDbPath(string dbName)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, "databases", dbName);
        }
    }
}