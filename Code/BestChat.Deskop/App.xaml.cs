// Ignore Spelling: Loc

namespace BestChat.Desktop
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : System.Windows.Application, Platform.DataLoc.IDataLocProvider
	{
		public System.IO.DirectoryInfo LocalDataLoc => new(System.IO.Path.Combine(System
			.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "Best Chat"));

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0022:Use expression body " +
			"for method", Justification = "Not fully implemented")]
		protected override void OnStartup(System.Windows.StartupEventArgs e)
		{
			base.OnStartup(e);

			//IRC.Protocol_Module.ProtocolDef.instance.Init(Prefs.Data.Prefs.instance, ClientConversation
				//.instance);

			// TODO: Make the above statement work.
		}
	}
}