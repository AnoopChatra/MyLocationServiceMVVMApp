using System;
using System.ComponentModel;
using System.Windows.Input;
using MyLocation.Services;
using Xamarin.Forms;
namespace MyLocation.ViewModels
{
    public class SecondVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand BackCommand { get; set; }
        public ICommand ShowCommand { get; set; }
        public ICommand ClearCommand { get; set; }
       
        double _xCoordinate;
        double _yCoordinate;
        INavigationService _navigationService;
        IMyLocationService _myLocationService;

        public double XCoordinate
        {
            set
            {
                if (_xCoordinate != value)
                {
                    _xCoordinate = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("XCoordinate"));
                }
            }
            get => _xCoordinate;
        }

        public double YCoordinate
        {
            set
            {
                if (_yCoordinate != value)
                {
                    _yCoordinate = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("YCoordinate"));
                }
            }
            get => _yCoordinate;
        }

        public SecondVM(INavigationService navigationService , IMyLocationService locationService)
        {
            _myLocationService = locationService;
            _navigationService = navigationService;

            _myLocationService.StartLocationUpdates();
          
            BackCommand = new Command(NavigateBack);
            ShowCommand = new Command(ShowCoordinates);
            ClearCommand = new Command(ClearCoordinates);
        }

        private void NavigateBack()
        {
            _myLocationService.StopLocationUpdates();
            _navigationService.MyPop();
        }

        private void ShowCoordinates()
        {
            var location = _myLocationService.GetLocation();
            XCoordinate = location["Xco-ordinate"];
            YCoordinate = location["Yco-ordinate"];
        }

        private void ClearCoordinates()
        {
            XCoordinate = 0;
            YCoordinate = 0;
        }
    }
}
