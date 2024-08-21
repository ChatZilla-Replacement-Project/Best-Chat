// Ignore Spelling: Prefs Ctrls Ctrl Mgrs Mgr

namespace BestChat.Platform.Prefs.Ctrls
{
	public abstract class VisualPrefsTabCtrl : GUI.Ctrls.AbstractVisualCtrl
	{
		#region Constructors & Deconstructors
			protected VisualPrefsTabCtrl()
			{
				if(System.Windows.Application.Current is DataLoc.IDataLocProvider)
					throw new System.InvalidProgramException("The default constructors of BestChat.Platform.Prefs.Ctrls and its derived " +
						"classes are for designer use only.  They aren't not meant for use at runtime.");
			}

			protected VisualPrefsTabCtrl(in string strLocalizedShortName, in string strLocalizedLongDesc, in
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
			public readonly Data.AbstractMgr? mgrUs;
		#endregion

		#region Properties
			public Data.AbstractMgr Mgr => mgrUs ?? throw new System.InvalidProgramException("BestChat.Platform.Prefs.Ctrls" +
				".VisualPrefsTabCtrl.Mgr accessed at runtime.");

			public virtual System.Collections.Generic.IEnumerable<System.Type> HandlesChildMgrsOfType => [];
		#endregion

		#region Methods
			protected override void OnInitialized(System.EventArgs e)
			{
				base.OnInitialized(e);

				DataContext = mgrUs;
			}
		#endregion

		#region Event Handlers
		#endregion
	}
}