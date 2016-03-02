﻿using MyTrips.Interfaces;
#if WINDOWS_UWP
using MyTrips.UWP.Helpers;
using ObdLibUWP;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrips.Shared
{
    public class OBDDeviceSim : IOBDDevice
    {
        #if WINDOWS_UWP
        ObdWrapper obdWrapper = new ObdWrapper();

        public async Task Disconnect()
        {
            await this.obdWrapper.Disconnect();
        }

        public async Task Initialize()
        {
            await this.obdWrapper.Init(true);
        }

        public Dictionary<string, string> ReadData()
        {
            return this.obdWrapper.Read();
        }
        #else

     

        public Task Disconnect()
        {
            return Task.FromResult(true);
        }

        public Task Initialize()
        {
            return Task.FromResult(true);
        }

        public Dictionary<string, string> ReadData()
        {
            return new Dictionary<string, string>();
        }
        #endif
    }
}
