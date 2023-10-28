// Ignore Spelling: Prefs

namespace BestChat.IRC.Data.Prefs
{
	public class PrefsMgr : Platform.Prefs.Data.AbstractChildMgr
	{
		#region Constructors & Deconstructors
			private PrefsMgr(in Platform.Prefs.Data.AbstractMgr mgrParent) : base(mgrParent, "IRC",
				Resources.strIrcName, Resources.strIrcLongDesc)
			{
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
			public override event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
		#endregion

		#region Constants
		#endregion

		#region Helper Types
		#endregion

		#region Members
			private static PrefsMgr? mgr = null;
		#endregion

		#region Properties
			public static PrefsMgr Mgr => mgr ?? throw new System.InvalidProgramException("Call BestChat" +
				".IRC.Data.Prefs.PrefsMgr.Init before accessing the Mgr value");
		#endregion

		#region Methods
			public static PrefsMgr Init(in Platform.Prefs.Data.AbstractMgr mgrParent) => mgr = new
				(mgrParent);
		#endregion

		#region Event Handlers
		#endregion
	}
}