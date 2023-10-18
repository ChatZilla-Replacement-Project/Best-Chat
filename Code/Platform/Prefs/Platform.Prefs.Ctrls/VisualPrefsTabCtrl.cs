// Ignore Spelling: Prefs Ctrls Ctrl

using BestChat.Platform.Prefs.Data;

namespace BestChat.Platform.Prefs.Ctrls
{
	public abstract class VisualPrefsTabCtrl : GUI.Ctrls.AbstractVisualTabCtrl
	{
		#region Constructors & Deconstructors
			public VisualPrefsTabCtrl(in string strLocalizedShortName, in string strLocalizedLongDesc, in
				AbstractMgr mgrUs) : base(strLocalizedShortName, strLocalizedLongDesc) => this.mgrUs = mgrUs;
		#endregion

		#region Delegates
		#endregion

		#region Events
		#endregion

		#region Constants
			#region Dependency Properties
			#endregion

			#region Routed Events
			#endregion
		#endregion

		#region Helper Types
		#endregion

		#region Members
			public readonly AbstractMgr mgrUs;
		#endregion

		#region Properties
			public AbstractMgr Mgr => mgrUs;
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}