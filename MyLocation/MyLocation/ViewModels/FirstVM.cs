using System;
using System.Windows.Input;
using MyLocation.Services;
using Xamarin.Forms;

namespace MyLocation.ViewModels
{
    public class FirstVM
    {
        public ICommand NextCommand { get; set; }
        INavigationService _navigationService;
        IMyLocationService _locationService;
       
        public FirstVM(IMyLocationService locationService, INavigationService navigationService)
        {
            NextCommand = new Command(Navigate);
            _navigationService = navigationService;
            _locationService = locationService;
        }

        public void Navigate()
        {
            _navigationService.MyPush(new SecondVM(_navigationService,_locationService));
        }
    }
}
