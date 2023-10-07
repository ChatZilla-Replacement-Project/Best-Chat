// Ignore Spelling: Bnc

namespace BestChat.IRC.Global.View
{
	/// <summary>
	/// Interaction logic for BncListEditor.xaml
	/// </summary>
	public partial class BncListEditor : System.Windows.Window
	{
		#region Constructors & Deconstructors
			public BncListEditor()
			{
				InitializeComponent();

				
			}
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

				DataContext = Model.NetworkMgr.mgr.AllNetworksSortedByName;
			}
		#endregion

		#region Event Handlers
			private void OnAddClicked(object sender, System.Windows.RoutedEventArgs e)
			{
				NetworkEditorDlg dlg = new(false, new Data.Defs.UserNetwork()
					.MakeEditableVersion())
				{
					Owner = this,
				};

				if(dlg.ShowDialog() == true)
					Model.NetworkMgr.mgr.AddNetwork(dlg.eunetWhatsBeingEdited.unetOriginal);
			}

			private void OnEditClicked(object sender, System.Windows.RoutedEventArgs e)
			{
				if(dgMain.SelectedItem != null)
				{
					NetworkEditorDlg dlg = new(true, ((Data.Defs.UserNetwork)dgMain
						.SelectedItem).MakeEditableVersion())
					{
						Owner = this,
					};

					if(dlg.ShowDialog() == true)
						dlg.eunetWhatsBeingEdited.Save();
				}
			}

			private void OnDelClicked(object sender, System.Windows.RoutedEventArgs e)
			{
				if(dgMain.SelectedItem != null)
					Model.NetworkMgr.mgr.RemoveNetwork(((Data.Defs.UserNetwork)dgMain.SelectedItem).Name);
			}

			private void OnCloseClicked(object objSender, System.Windows.RoutedEventArgs e) => Close();
		#endregion
	}
}