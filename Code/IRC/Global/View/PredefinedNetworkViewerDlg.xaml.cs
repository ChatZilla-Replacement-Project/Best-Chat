namespace BestChat.IRC.Global.View
{
	/// <summary>
	/// Interaction logic for PredefinedNetworkViewerDlg.xaml
	/// </summary>
	public partial class PredefinedNetworkViewerDlg : System.Windows.Window
	{
		public PredefinedNetworkViewerDlg(System.Windows.Window wndOwner, Data.Defs.Network networkToView)
		{
			InitializeComponent();

			Owner = wndOwner;

			DataContext = networkToView;
		}

		private void OnCloseClicked(object objSender, System.Windows.RoutedEventArgs e) => Close();

		private void OnVisitHomepageClicked(object objSender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Handle the click
		}

		private void OnServerListAutoGeneratingColumns(object objSender, System.Windows.Controls
			.DataGridAutoGeneratingColumnEventArgs e) => e.Cancel = true;
	}
}