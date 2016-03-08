﻿using System;
using System.Collections.Generic;
#if !BACKEND
using Newtonsoft.Json;
using MyTrips.Utils;
#endif
namespace MyTrips.DataObjects
{
    public class TripPoint: BaseDataObject
    {
        public string TripId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Speed { get; set; }

        public DateTime RecordedTimeStamp { get; set; }

        public int Sequence {get;set;}

        public double RPM { get; set;}

        public double BarometricPressure { get; set; }

        public double OutsideTemperature { get; set; }

        public double InsideTemperature { get; set; }

        public double EngineFuelRate { get; set; }

        public bool HasOBDData { get; set; }

        public Dictionary<String, String> OBDData { get; set; }

        #if !BACKEND
        [JsonIgnore]
        public string DisplayTemp
        {
            get 
            {
                if (!HasOBDData)
                    return "N/A";
                
                return  Settings.Current.MetricTemp ? (OutsideTemperature.ToString("N1") + "°C") :
                                                 (((OutsideTemperature * 1.8) + 32).ToString("N1") + "°F");
            }
        }
        #endif
    }
}