using Foundation;
using System.Collections.Generic;
using UIKit;
using System;
using MyTrips.ViewModel;

namespace MyTrips.iOS
{
    public partial class ProfileTableViewController : UITableViewController
    {
		const string STAT_CELL_IDENTIFIER = "STAT_CELL_IDENTIFIER";
		List<DrivingStatistic> data;

		public ProfileViewModel ViewModel { get; set; }

		public ProfileTableViewController(IntPtr handle) : base(handle) { }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			ViewModel = new ProfileViewModel();
			NavigationItem.Title = $"{ViewModel.Settings.UserFirstName} {ViewModel.Settings.UserLastName}";

			imgAvatar.Layer.CornerRadius = imgAvatar.Frame.Width / 2;
			imgAvatar.Layer.BorderWidth = 2;
			imgAvatar.Layer.BorderColor = "15A9FE".ToUIColor().CGColor;
			imgAvatar.Layer.MasksToBounds = true;

			data = new List<DrivingStatistic>
			{
				new DrivingStatistic { Name = "Total Distance", Value = $"{ViewModel.TotalDistance}"},
				new DrivingStatistic { Name = "Total Duration", Value = $"{ViewModel.TotalTime}"},
				new DrivingStatistic { Name = "Average Speed", Value = $"{ViewModel.AvgSpeed}" },
				new DrivingStatistic { Name = "Average Consumption", Value = "2.5 gallons"},
				new DrivingStatistic { Name = "Hard Breaks", Value = "21"}
			};
		}

		#region UITableViewSource
		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 60;
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			return data.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(STAT_CELL_IDENTIFIER) as ProfileStatCell;

			cell.Name = data[indexPath.Row].Name;
			cell.Value = data[indexPath.Row].Value;

			return cell;
		}
		#endregion
    }
}