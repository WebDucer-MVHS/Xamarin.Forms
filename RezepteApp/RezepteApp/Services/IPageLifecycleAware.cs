namespace RezepteApp.Services
{
    public interface IPageLifecycleAware
    {
        void OnStart();

        void OnStop();
    }
}
