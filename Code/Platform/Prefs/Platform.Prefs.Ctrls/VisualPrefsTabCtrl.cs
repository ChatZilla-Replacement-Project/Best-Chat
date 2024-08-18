// Ignore Spelling: Prefs Ctrls Ctrl Mgrs Mgr

namespace BestChat.Platform.Prefs.Ctrls
{
	public abstract class VisualPrefsTabCtrl : GUI.Ctrls.AbstractVisualCtrl
	{
		#region Constructors & Deconstructors
			public VisualPrefsTabCtrl(in string strLocalizedShortName, in string strLocalizedLongDesc, in
				Data.AbstractMgr mgrUs) : base(strLocalizedShortName, strLocalizedLongDesc) => this.mgrUs = mgrUs;
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
			public readonly Data.AbstractMgr mgrUs;
		#endregion

		#region Properties
			public Data.AbstractMgr Mgr => mgrUs;

			public virtual System.Collections.Generic.IEnumerable<Data.AbstractChildMgr> HandlesChildMgrsOfType => [];
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}