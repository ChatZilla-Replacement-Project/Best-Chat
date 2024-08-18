// Ignore Spelling: Prefs

namespace BestChat.Desktop
{
	/// <summary>
	/// Interaction logic for PrefsWnd.xaml
	/// </summary>
	public partial class PrefsWnd : System.Windows.Window
	{
		#region Constructors & Deconstructors
			public PrefsWnd()
			{
				InitializeComponent();
			}

			static PrefsWnd()
			{
				//Platform.Prefs.Ctrls.VisualPrefsTreeData.RegisterDataEditorCtrlType(typeof(Prefs.Data.Prefs.GlobalPrefs))
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
		#endregion

		#region Event Handlers
			private void OnHomePageLinkClicked(object objSender, System.Windows.RoutedEventArgs e)
			{
				using(System.Diagnostics.Process process = new System.Diagnostics.Process()
				{
					StartInfo = new System.Diagnostics.ProcessStartInfo()
					{
						UseShellExecute = true,
						FileName = "https://github.com/ChatZilla-Replacement-Project",
					}
				})
				{
					process.Start();
				}
			}
		#endregion
	}
}