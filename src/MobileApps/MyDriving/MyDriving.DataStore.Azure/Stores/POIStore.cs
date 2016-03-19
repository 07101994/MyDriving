﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.

using MyDriving.DataObjects;
using MyDriving.DataStore.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDriving.DataStore.Azure.Stores
{
    public class POIStore : BaseStore<POI>, IPOIStore
    {
        public async Task<IEnumerable<POI>> GetItemsAsync(string tripId)
        {
            return new List<POI>();
        }
    }
}