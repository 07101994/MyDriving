﻿using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;

using MyTrips.Droid.Fragments;
using Android.Support.V7.App;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using MyTrips.Utils;
using Android.Runtime;
using System;
using System.Threading.Tasks;

namespace MyTrips.Droid
{
    [Activity (Label = "My Trips", Icon = "@drawable/icon", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : BaseActivity
    {

        DrawerLayout drawerLayout;
        NavigationView navigationView;

        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.activity_main;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            InitializeHockeyApp();
            drawerLayout = this.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            //Set hamburger items menu
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);

            //setup navigation view
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            //handle navigation
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);

                ListItemClicked(e.MenuItem.ItemId);

                Snackbar.Make(drawerLayout, "You selected: " + e.MenuItem.TitleFormatted, Snackbar.LengthLong)
                    .Show();

                drawerLayout.CloseDrawers();
            };


            //if first time you will want to go ahead and click first item.
            if (bundle == null)
            {
                ListItemClicked(Resource.Id.menu_past_trips);
            }
        }

        void InitializeHockeyApp()
        {
            if (string.IsNullOrWhiteSpace(Logger.HockeyAppKey))
                return;
            // Register the crash manager before Initializing the trace writer
            HockeyApp.CrashManager.Register (this, Logger.HockeyAppKey); 

            //Register to with the Update Manager
            HockeyApp.UpdateManager.Register (this, Logger.HockeyAppKey);

            // Initialize the Trace Writer
            HockeyApp.TraceWriter.Initialize ();

            // Wire up Unhandled Expcetion handler from Android
            AndroidEnvironment.UnhandledExceptionRaiser += (sender, args) => 
                {
                    // Use the trace writer to log exceptions so HockeyApp finds them
                    HockeyApp.TraceWriter.WriteTrace(args.Exception);
                    args.Handled = true;
                };

            // Wire up the .NET Unhandled Exception handler
            AppDomain.CurrentDomain.UnhandledException +=
                (sender, args) => HockeyApp.TraceWriter.WriteTrace(args.ExceptionObject);

            // Wire up the unobserved task exception handler
            TaskScheduler.UnobservedTaskException += 
                (sender, args) => HockeyApp.TraceWriter.WriteTrace(args.Exception);

        }

        int oldPosition = -1;
        private void ListItemClicked(int itemId)
        {
            //this way we don't load twice, but you might want to modify this a bit.
            if (itemId == oldPosition)
                return;

            oldPosition = itemId;

            Android.Support.V4.App.Fragment fragment = null;
            switch (itemId)
            {
                case Resource.Id.menu_past_trips:
                    fragment = FragmentPastTrips.NewInstance();
                    break;
                case Resource.Id.menu_current_trip:
                    fragment = FragmentCurrentTrip.NewInstance();
                    break;
                case Resource.Id.menu_routes:
                    fragment = FragmentRecommendedRoutes.NewInstance();
                    break;
                case Resource.Id.menu_settings:
                    fragment = FragmentSettings.NewInstance();
                    break;
            }

            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}


