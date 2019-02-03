using MyLocation.Services;
using MyLocation.Views;
using Xamarin.Forms;

namespace MyLocation
{
    public partial class App : Application
    {
        public App(IMyLocationService locationService)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FirstPage(locationService, new NavigationService()));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
