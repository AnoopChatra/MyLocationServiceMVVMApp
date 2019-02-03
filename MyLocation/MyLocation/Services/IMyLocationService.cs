using System;
using System.Collections.Generic;

namespace MyLocation.Services
{
    public interface IMyLocationService
    {
        
        bool IsLocationTurnedOn();

        Dictionary<string, double> GetLocation();

        void StartLocationUpdates();

        void StopLocationUpdates();


    }
}
