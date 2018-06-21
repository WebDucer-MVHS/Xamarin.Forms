using Prism.Ioc;
using RezepteApp.Droid.Services;
using RezepteApp.Services;

namespace RezepteApp.Droid
{
    public class AndroidInitializer : Prism.IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            container.RegisterSingleton<IPathService, AndroidPathService>();
        }
    }
}