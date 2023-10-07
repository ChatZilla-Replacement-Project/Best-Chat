namespace BestChat.GUI.Ctrls
{
	using Util.Ext.WPF;

	/// <summary>
	/// Interaction logic for ShowHelpBtn.xaml
	/// </summary>
	public partial class ShowHelpBtn : System.Windows.Controls.Primitives.ToggleButton
	{
		public ShowHelpBtn()
		{
			InitializeComponent();
		}

		protected override void OnInitialized(System.EventArgs e)
		{
			base.OnInitialized(e);

			ToolTip = Ctrls.Resources.strShowHelpButtonToolTipText;

		}

		private static readonly System.Collections.Generic.Dictionary<System.Windows.Window, ShowHelpBtn?>
			mapOfOwnerWndToActiveHelpBtn = new();

		private System.Windows.Window? wndTopLevelParent;

		protected override void OnChecked(System.Windows.RoutedEventArgs e)
		{
			base.OnChecked(e);

			if(!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) && wndTopLevelParent != null)
			{
				ShowHelpBtn? chkChecked = mapOfOwnerWndToActiveHelpBtn[wndTopLevelParent];
				if(chkChecked != null && chkChecked != this && IsChecked == true)
					chkChecked.IsChecked = false;

				if(IsChecked == true)
					mapOfOwnerWndToActiveHelpBtn[wndTopLevelParent] = this;
				else if(chkChecked == this)
					mapOfOwnerWndToActiveHelpBtn[wndTopLevelParent] = null;
			}
		}

		private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
		{
			if(!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
			{
				wndTopLevelParent = this.FindTopLevelOwner();
				if(wndTopLevelParent != null && !mapOfOwnerWndToActiveHelpBtn.ContainsKey(wndTopLevelParent))
					mapOfOwnerWndToActiveHelpBtn[wndTopLevelParent] = null;
			}
		}
	}
}