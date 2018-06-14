using Prism.Ioc;
using RezepteApp.DB;
using RezepteApp.i18n;
using RezepteApp.Services;
using RezepteApp.Services.Fakes;
using RezepteApp.ViewModels;
using System;
using System.Collections.Generic;
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

            // String interpolation
            NavigationService.NavigateAsync(
                $"{nameof(NavigationPage)}/{nameof(Views.ReceiptListPage)}");

            //NavigationService.NavigateAsync(
            //    string.Format("{0}/{1}", nameof(NavigationPage), nameof(Views.ReceiptListPage)
            //    ));

            //MainPage = new NavigationPage(new Views.ReceiptListPage()
            //{
            //    BindingContext = new ViewModels.ReceiptListViewModel(new FakeReceiptRepo())
            //});
        }
    }
}
