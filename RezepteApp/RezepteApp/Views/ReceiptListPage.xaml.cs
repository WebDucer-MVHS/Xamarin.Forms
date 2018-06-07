
using RezepteApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RezepteApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReceiptListPage : ContentPage
	{
		public ReceiptListPage ()
		{
			InitializeComponent ();
		}

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    var vm = this.BindingContext as IPageLifecycleAware;
        //    if (vm != null)
        //    {
        //        vm.OnStart();
        //    }
        //}

        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();

        //    var vm = this.BindingContext as IPageLifecycleAware;
        //    if (vm != null)
        //    {
        //        vm.OnStop();
        //    }
        //}
    }
}