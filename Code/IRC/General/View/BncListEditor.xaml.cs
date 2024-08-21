// Ignore Spelling: Bnc

namespace BestChat.IRC.General.View
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

				//DataContext = Data.BncMgr.mgr.AllItemsSortedByName;
			}
		#endregion

		#region Event Handlers
			private void OnAddClicked(object sender, System.Windows.RoutedEventArgs e)
			{
			}

			private void OnEditClicked(object sender, System.Windows.RoutedEventArgs e)
			{
			}

			private void OnDelClicked(object sender, System.Windows.RoutedEventArgs e)
			{
			}

			private void OnCloseClicked(object objSender, System.Windows.RoutedEventArgs e) => Close();
		#endregion
	}
}