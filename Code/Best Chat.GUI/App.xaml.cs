namespace BestChat.GUI
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : System.Windows.Application, Platform.HttpClientOwner.IHttpClientOwner,
		Platform.DataLoc.IDataLocProvider
	{
		static App() => client = new();

		private static readonly System.Net.Http.HttpClient client;

		public System.Net.Http.HttpClient HttpClient => client;

		public System.IO.DirectoryInfo LocalDataLoc => new(System.IO.Path.Combine(System
			.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "Best Chat"));
	}
}