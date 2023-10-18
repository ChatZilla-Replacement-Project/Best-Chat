// Ignore Spelling: Prefs

namespace BestChat.Platform.Prefs.Data
{
	public abstract class AbstractMgr : Platform.Data.Obj<AbstractMgr>
	{
		#region Constructors & Deconstructors
			protected AbstractMgr()
			{
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
			private readonly System.Collections.Generic.SortedDictionary<string, ItemBase> mapItemsByName = new
				();

			private readonly System.Collections.Generic.SortedDictionary<string, AbstractChildMgr>
				mapChildMgrByName = new();
		#endregion

		#region Properties
			public System.Collections.Generic.IReadOnlyDictionary<string, ItemBase> ItemsByName =>
				mapItemsByName;

			public System.Collections.Generic.IReadOnlyDictionary<string, AbstractChildMgr> ChildMgrByName =>
				mapChildMgrByName;
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}