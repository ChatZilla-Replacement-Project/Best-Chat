// Ignore Spelling: IRC

namespace BestChat.IRC.Global.View
{
	/// <summary>
	/// Interaction logic for NetworkList.xaml
	/// </summary>
	public partial class NetworkListDlg : System.Windows.Window
	{
		#region Constructors & Deconstructors
			public NetworkListDlg() => InitializeComponent();
		#endregion

		#region Delegates
		#endregion

		#region Events
		#endregion

		#region Constants
		#endregion

		#region Helper Types
		#endregion

		#region Members
		#endregion

		#region Properties
		#endregion

		#region Methods
			protected override void OnInitialized(System.EventArgs e)
			{
				base.OnInitialized(e);

				dgPredefined.SetBinding(System.Windows.Controls.ItemsControl.ItemsSourceProperty, new System
					.Windows.Data.Binding("AllItemsSortedByName")
					{
						Source = Data.NetworkMgr.mgr,
						NotifyOnTargetUpdated = true,
					});
				dgUser.SetBinding(System.Windows.Controls.ItemsControl.ItemsSourceProperty, new System
					.Windows.Data.Binding("AllItemsSortedByName")
					{
						Source = Data.UserNetworkMgr.mgr,
						NotifyOnTargetUpdated = true,
					});

				if(dgPredefined.Items.Count > 0)
					dgPredefined.SelectedIndex = 0;

				if(dgUser.SelectedIndex > 0)
					dgUser.SelectedIndex = 0;
			}
		#endregion

		#region Event Handlers
			private void OnAddClicked(object objSender, System.Windows.RoutedEventArgs e)
			{
				NetworkEditorDlg dlg = new(false, new Data.Defs.UserNetwork()
					.MakeEditableVersion())
				{
					Owner = this,
				};

				if(dlg.ShowDialog() == true)
					Data.UserNetworkMgr.mgr.Add(dlg.eunetWhatsBeingEdited.unetOriginal);
			}

			private void OnEditClicked(object objSender, System.Windows.RoutedEventArgs e)
			{
				if(dgUser.SelectedItem != null)
				{
					NetworkEditorDlg dlg = new(true, ((Data.Defs.UserNetwork)dgUser
						.SelectedItem).MakeEditableVersion())
					{
						Owner = this,
					};

					if(dlg.ShowDialog() == true)
						dlg.eunetWhatsBeingEdited.Save();
				}
			}

			private void OnDelClicked(object objSender, System.Windows.RoutedEventArgs e)
			{
				if(dgUser.SelectedItem != null)
					Data.NetworkMgr.mgr.Remove(((Data.Defs.UserNetwork)dgUser.SelectedItem).Name);
			}

			private void OnCloseClicked(object objSender, System.Windows.RoutedEventArgs e) => Close();

			private void OnUserAutoGeneratingColumn(object objSender, System.Windows.Controls
				.DataGridAutoGeneratingColumnEventArgs e) => e.Cancel = true;

			private void OnPredefinedAutoGeneratingColumn(object objSender, System.Windows.Controls
				.DataGridAutoGeneratingColumnEventArgs e) => e.Cancel = true;

			private void OnViewPredefinedNetworkDetailsClicked(object objSender, System.Windows.RoutedEventArgs e)
				=> new PredefinedNetworkViewerDlg(this, (Data.Defs.Network)dgPredefined.SelectedValue).ShowDialog();

			private void OnHidePredefinedNetworkClicked(object objSender, System.Windows.RoutedEventArgs e) =>
				Data.UserNetworkMgr.mgr.Add(new((Data.Defs.Network)dgPredefined.SelectedValue)
				{
					IsHidden = true,
				});
		#endregion
	}
}