﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.

using System.Threading;
using Xamarin.UITest;
using NUnit.Framework;
using System.Linq;
using Xamarin.UITest.Android;
using Xamarin.UITest.iOS;

namespace MyDriving.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
	public abstract class AbstractSetup
	{
        protected IApp App;
		protected Platform platform;
		protected bool OnAndroid;
		protected bool OniOS;

		public AbstractSetup(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public virtual void BeforeEachTest()
		{
			App = AppInitializer.StartApp(platform);
			OnAndroid = App.GetType() == typeof(AndroidApp);
			OniOS = App.GetType() == typeof(iOSApp);

			new LoginPage ()
					.SkipAuthentication ();
				
			//Note: Sleep only there to let map
			//load before screenshotting
			Thread.Sleep(2000);

			//double evolveLongitude =  28.427925;
			//double evolveLatitude  = -81.470973;

			//go to Evolve 2016!
			//this.App.Device.SetLocation(evolveLatitude,evolveLongitude);

        }

        public void ClearKeychain()
        {
            if (OnAndroid)
            {
                App = ConfigureApp.Android.ApkFile(AppInitializer.apkPath).StartApp();
                return;
            }

            else
            {
                if (!App.Query("LoginWithFacebook").Any())
                {
                    App.TestServer.Post("/keychain", new object());
                    App = ConfigureApp.iOS.InstalledApp("com.microsoft.mydriving").StartApp();
    			}
            }
		}
	}
}