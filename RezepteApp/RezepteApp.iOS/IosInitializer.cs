using System;
using Prism.Ioc;
using RezepteApp.iOS.Services;
using RezepteApp.Services;

namespace RezepteApp.iOS
{
    public class IosInitializer : Prism.IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            container.RegisterSingleton<IPathService, IosPathService>();
        }
    }
}