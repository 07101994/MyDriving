﻿using System;
using CoreLocation;

namespace MyTrips.iOS
{
	public class WaypointAnnotation : BaseCustomAnnotation
	{
		public WaypointAnnotation(CLLocationCoordinate2D annotationLocation) : base(annotationLocation)
		{ 

		}
	}
}

