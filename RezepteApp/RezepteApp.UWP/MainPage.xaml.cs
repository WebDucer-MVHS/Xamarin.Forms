namespace RezepteApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new RezepteApp.App(new UwpInitializer()));
        }
    }
}
