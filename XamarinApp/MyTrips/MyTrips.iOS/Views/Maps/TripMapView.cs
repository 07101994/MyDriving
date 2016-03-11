using System;

using CoreLocation;
using MapKit;

namespace MyTrips.iOS
{
    public partial class TripMapView : MKMapView
    {
		public TripMapView(IntPtr handle) : base(handle)
		{
		}

		public void DrawRoute(CLLocationCoordinate2D[] route)
		{
			AddOverlay(MKPolyline.FromCoordinates(route));
		}
    }
}