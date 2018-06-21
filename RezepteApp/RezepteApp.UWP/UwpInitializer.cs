using Prism.Ioc;
using RezepteApp.Services;
using RezepteApp.UWP.Services;

namespace RezepteApp.UWP
{
    class UwpInitializer : Prism.IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            container.RegisterSingleton<IPathService, UwpPathService>();
        }
    }
}
