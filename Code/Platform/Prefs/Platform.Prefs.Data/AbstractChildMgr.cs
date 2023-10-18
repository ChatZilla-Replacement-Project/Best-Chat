namespace BestChat.Platform.Prefs.Data
{
	public abstract class AbstractChildMgr : AbstractMgr
	{
		#region Constructors & Deconstructors
			protected AbstractChildMgr(in AbstractMgr mgrParent)
			{
				this.mgrParent = mgrParent;
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
			public readonly AbstractMgr mgrParent;
		#endregion

		#region Properties
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}