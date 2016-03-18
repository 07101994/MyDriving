using System;

using Foundation;
using UIKit;

namespace MyDriving.iOS
{
	public partial class TripSummaryCell : UITableViewCell
	{
		public TripSummaryCell(IntPtr handle) : base(handle) { }
		public TripSummaryCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId) { }

		public string Name
		{
			get { return nameLabel.Text; }
			set { nameLabel.Text = value; }
		}

		public string Value
		{
			get { return valueLabel.Text; }
			set { valueLabel.Text = value; }
		}
    }
}