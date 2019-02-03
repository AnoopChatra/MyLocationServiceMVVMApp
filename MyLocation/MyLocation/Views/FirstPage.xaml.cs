using MyLocation.Services;
using MyLocation.ViewModels;
using Xamarin.Forms;

namespace MyLocation
{
    public partial class FirstPage : ContentPage
    {
        FirstVM firstPageVM;
        public FirstPage(IMyLocationService locationservice , INavigationService navigationService)
        {
            InitializeComponent();
            BindingContext = new FirstVM(locationservice,navigationService);
        }
    }
}
