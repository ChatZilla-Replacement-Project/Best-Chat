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
			public System.Collections.Generic.IReadOnlyDictionary<string, object> ToTupleList()
			{
				System.Collections.Generic.SortedDictionary<string, object> mapFieldsByName = new
					();

				foreach(ItemBase itemCur in mapItemsByName.Values)
					mapFieldsByName[itemCur.ItemName] = itemCur.ValAsText;

				foreach(AbstractChildMgr cmgrCur in mapChildMgrByName.Values)
					mapFieldsByName[cmgrCur.Name] = cmgrCur.ToTupleList();

				return mapFieldsByName;
			}
		#endregion

		#region Event Handlers
		#endregion
	}
}