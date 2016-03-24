using Foundation;
using System;
using UIKit;

namespace MyDriving.iOS
{
	public partial class GettingStartedViewController : UIPageViewController
	{
		GettingStartedContentViewController pageOne = (GettingStartedContentViewController)UIStoryboard.FromName("Main", null).InstantiateViewController("gettingStartedContentViewController");

		public GettingStartedViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			pageOne.PageIndex = 0;
			pageOne.Image = UIImage.FromBundle("screen_1.png");

			SetViewControllers(new UIViewController[] { pageOne }, UIPageViewControllerNavigationDirection.Forward, true, null);
			DataSource = new PageViewControllerSource();
		}

		public class PageViewControllerSource : UIPageViewControllerDataSource
		{
			public override UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
			{
				var vc = (GettingStartedContentViewController)referenceViewController;
				var index = vc.PageIndex;

				return GettingStartedContentViewController.ControllerForPageIndex(index-1);
			}

			public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
			{
				var vc = (GettingStartedContentViewController)referenceViewController;
				var index = vc.PageIndex;

				return GettingStartedContentViewController.ControllerForPageIndex(index+1);
			}
		}
    }
}
 