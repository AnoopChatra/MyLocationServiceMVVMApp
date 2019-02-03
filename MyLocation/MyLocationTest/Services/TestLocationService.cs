using System;
using System.Collections.Generic;
using MyLocation.Services;

namespace MyLocationTest.Services
{
    public class TestLocationService :IMyLocationService
    {
        public TestLocationService()
        {
        }

        public Dictionary<string, double> GetLocation()
        {
            Dictionary<string, double> testLocation = new Dictionary<string, double>();
            testLocation.Add("Xco-ordinate",20.43);
            testLocation.Add("Yco-ordinate",40.43);
            return testLocation;
        }

        public bool IsLocationTurnedOn()
        {
            return true;

        }

        public void StartLocationUpdates()
        {
            
        }

        public void StopLocationUpdates()
        {
           
        }
    }
}
