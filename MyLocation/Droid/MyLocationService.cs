using System;
using System.Collections.Generic;
using Android.Content;
using Android.Locations;
using Android.OS;
using MyLocation.Services;
using Object = Java.Lang.Object;

namespace MyLocation.Droid
{
    public class MyLocationService:Object, IMyLocationService, ILocationListener
    {
        private const int TimeInterval = 1000; // 10 seconds
        private const int DistanceAccuracy = 10; // 10 meters
        private readonly LocationManager _locationManager;
        private double _xCoordinate;
        private double _yCoordinate;
        int count = 0;

        public MyLocationService()
        {
            _locationManager = (LocationManager)MainActivity.mContxt.GetSystemService(Context.LocationService);
        }

        public bool IsLocationTurnedOn()
        {
            return _locationManager.IsProviderEnabled(LocationManager.GpsProvider);
        }

        public Dictionary<string, double> GetLocation()
        {
            count = count + 1; 
            if (count == 1)
            {
                _xCoordinate = 30.476;
                _yCoordinate = 50.989;
            }
            else if(count == 2){
                _xCoordinate = 47.456;
                _yCoordinate = 68.789;
            }else{
                _xCoordinate = 77.156;
                _yCoordinate = 55.784;
                count = 0;
            }
            
            return new Dictionary<string, double>
            {
                {"Xco-ordinate", _xCoordinate}, {"Yco-ordinate", _yCoordinate}
            };
        }

        public void StartLocationUpdates()
        {
            //location updates would re received once in 10 seconds with 10 meters accuracy.
           // _locationManager.RequestLocationUpdates(LocationManager.GpsProvider, TimeInterval, DistanceAccuracy, this);
        }

        public void StopLocationUpdates()
        {
            _locationManager.RemoveUpdates(this);
        }

        #region ILocationListener callbacks

        public void Dispose()
        {
        }

        public IntPtr Handle { get; }
        public void OnLocationChanged(Location location)
        {
            _xCoordinate = location.Latitude;
            _yCoordinate = location.Longitude;
        }

        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {
        }

        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
        }

        #endregion
    }
}
