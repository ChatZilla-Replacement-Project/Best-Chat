// Ignore Spelling: Prefs

namespace BestChat.GUI
{
	/// <summary>
	/// Interaction logic for PrefsWnd.xaml
	/// </summary>
	public partial class PrefsWnd : System.Windows.Window
	{
		public PrefsWnd()
		{
			InitializeComponent();
		}

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
	}
}