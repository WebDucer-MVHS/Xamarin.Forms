using DryIoc;
using Prism.Ioc;
using RezepteApp.DB;
using RezepteApp.i18n;
using RezepteApp.Services;
using RezepteApp.Services.Fakes;
using RezepteApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Resources;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
[assembly: NeutralResourcesLanguage("en")]

namespace RezepteApp
{
	public partial class App : Prism.DryIoc.PrismApplication
	{
        public App(Prism.IPlatformInitializer initializer) : base(initializer)
        {

        }

		public App ()
		{
			
		}

        // Registrierung der navigation und der Services
        protected override void RegisterTypes(IContainerRegistry container)
        {
            // Navigation
            container.RegisterForNavigation<NavigationPage>();
            container.RegisterForNavigation<Views.ReceiptListPage, ReceiptListViewModel>();
            container.RegisterForNavigation<MainPage, MainViewModel>();

            // Service
            //container.Register<IReceiptRepo, FakeReceiptRepo>();
            container.Register<IReceiptRepo, DbReceiptRepo>();
            container.Register<ReceiptContext>();
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            // Init Database
            InitDatabse();

            // String interpolation
            NavigationService.NavigateAsync(
                $"{nameof(NavigationPage)}/{nameof(Views.ReceiptListPage)}");
        }

        private void InitDatabse()
        {
            try
            {
                using (var db = Container.Resolve<ReceiptContext>())
                {
                    db.Database.EnsureCreated();
                }

                // Ohne Using
                var db2 = Container.Resolve<ReceiptContext>();
                db2.Database.EnsureCreated();
                db2.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        protected override Rules CreateContainerRules()
        {
            return base.CreateContainerRules()
                .WithoutThrowOnRegisteringDisposableTransient();
        }
    }
}
