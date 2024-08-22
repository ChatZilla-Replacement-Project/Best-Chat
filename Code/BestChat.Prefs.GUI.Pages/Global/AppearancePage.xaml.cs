// Ignore Spelling: Prefs Ctrls Mgrs

namespace BestChat.Prefs.GUI.Pages.Global
{
	/// <summary>
	/// Interaction logic for Global.xaml
	/// </summary>
	public partial class AppearancePage : Platform.Prefs.Ctrls.VisualPrefsTabCtrl
	{
		#region Constructors & Deconstructors
			public AppearancePage()
			{
				InitializeComponent();
			}

			public AppearancePage(Data.Prefs.GlobalPrefs.AppearancePrefs mgrUs) : base(Rsrcs.strGlobalAppearanceTitle, Rsrcs
				.strGlobalAppearanceDesc, mgrUs)
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
			public override System.Collections.Generic.IEnumerable<System.Type> HandlesChildMgrsOfType => [
				typeof(Data.Prefs.GlobalPrefs.AppearancePrefs.ConfModePrefs),
				typeof(Data.Prefs.GlobalPrefs.AppearancePrefs.FontPrefs),
				typeof(Data.Prefs.GlobalPrefs.AppearancePrefs.TimeStampPrefs),
				typeof(Data.Prefs.GlobalPrefs.AppearancePrefs.UserListPrefs)];
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}