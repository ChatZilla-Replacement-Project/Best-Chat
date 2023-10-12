// Ignore Spelling: Prefs

namespace BestChat.Platform.Prefs
{
	public abstract class Mgr : Data.Obj<Mgr>
	{
		#region Constructors & Deconstructors
			public Mgr()
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
			private System.Collections.Generic.SortedDictionary<string, IItem> mapAllItemsByName = new
				();

			private System.Collections.Generic.SortedDictionary<string, ChildMgr> mapAllChildMgrByName = new
				();
		#endregion

		#region Properties
			public System.Collections.Generic.IReadOnlyDictionary<string, IItem> AllItemsByName =>
				mapAllItemsByName;

			public System.Collections.Generic.IReadOnlyDictionary<string, ChildMgr> AllChildMgrByName =>
				mapAllChildMgrByName;
		#endregion

		#region Methods
			internal void AddItem(IItem itemNew) => mapAllItemsByName[itemNew.Name] = itemNew;

			internal void AddItem(ChildMgr mgrChildNew) => mapAllChildMgrByName[mgrChildNew.Name] = mgrChildNew;

			internal void OnChildPrefIsNowDirty() => MakeDirty();

			public System.Collections.Generic.IEnumerable<System.Tuple<string, object>> ToTupleList()
			{
				System.Collections.Generic.LinkedList<System.Tuple<string, object>> llistResults = new
				 ();

				foreach(ChildMgr mgrCurChild in mapAllChildMgrByName.Values)
					llistResults.AddLast(new System.Tuple<string, object>(mgrCurChild.strEnglishName,
						mgrCurChild.ToTupleList()));

				foreach(IItem itemCur in mapAllItemsByName.Values)
					llistResults.AddLast(new System.Tuple<string, object>(itemCur.EnglishName, itemCur
						.GetCurValAsString()));

				return llistResults;
			}
		#endregion

		#region Event Handlers
		#endregion
	}

	public abstract class ChildMgr : Mgr
	{
		public ChildMgr(Mgr mgrParent, string strEnglishName, string strName, string strHelpText)
		{
			this.mgrParent = mgrParent;

			this.strEnglishName = strEnglishName;
			this.strName = strName;
			this.strHelpText = strHelpText;

			mgrParent.AddItem(this);
		}


		public readonly Mgr mgrParent;

		public Mgr ParentMgr => mgrParent;


		public readonly string strEnglishName;

		public readonly string strName;

		public string Name => strName;

		public readonly string strHelpText;

		public string HelpText => strHelpText;
	}
}