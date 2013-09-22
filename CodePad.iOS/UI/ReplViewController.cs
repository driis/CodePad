using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Linq;

namespace CodePad.iOS.UI
{
	public partial class ReplViewController : UIViewController, IUITextFieldDelegate
	{
		CodePad.iOS.Engine.ReplSession _session;

		public ReplViewController (Engine.ReplSession session) : base ("ReplViewController", null)
		{
			_session = session;
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad();
			UpdateHistory ();
			this.inputBox.BecomeFirstResponder ();
			this.inputBox.ShouldReturn = field => {
				string text = inputBox.Text;
				var statement = new Engine.Statement(text);
				statement = _session.Execute(statement);
				inputBox.Text = String.Empty;
				historyView.Text = historyView.Text + Environment.NewLine + statement.ExecutionResult.ToString();
				return false;
			};
		}

		void UpdateHistory()
		{
			this.historyView.Text = String.Join (Environment.NewLine, _session.History.Select (x => x.ToString ()));
		}

		public override void SetValueForKey(NSObject value, NSString key)
		{
			base.SetValueForKey (value, key);
		}
	}
}

