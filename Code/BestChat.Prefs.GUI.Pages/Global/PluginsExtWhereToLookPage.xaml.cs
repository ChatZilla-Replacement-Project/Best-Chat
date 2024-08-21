// Ignore Spelling: Prefs

namespace BestChat.Prefs.GUI.Pages.Global
{
	/// <summary>
	/// Interaction logic for PluginsExtWhereToLookPage.xaml
	/// </summary>
	public partial class PluginsExtWhereToLookPage : Platform.Prefs.Ctrls.VisualPrefsTabCtrl
	{
		#region Constructors & Deconstructors
			public PluginsExtWhereToLookPage()
			{
				InitializeComponent();
			}

			public PluginsExtWhereToLookPage(Data.Prefs.GlobalPrefs.PluginPrefs.ExtPrefs.WhereToLookPrefs mgrUs) : base(Rsrcs
				.strGlobalPluginExtWhereToLookTitle, Rsrcs.strGlobalPluginExtWhereToLookDesc, mgrUs)
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
		#endregion

		#region Event Handlers
		#endregion
	}
}