// Ignore Spelling: Ctrl

namespace BestChat.Platform.Prefs.Ctrls
{
	using Util.Ext;

	public sealed class VisualPrefsTreeData : System.Windows.DependencyObject
	{
		#region Constructors & Deconstructors
			public VisualPrefsTreeData(Data.AbstractMgr mgr)
			{
				if(!mapDataMgrToCtrlType.ContainsKey(typeof(Data.AbstractMgr)))
					throw new System.ArgumentException("Unable to construct the prefs manager to control relationship as no control type was " +
						"specified.", nameof(mgr));

				Mgr = mgr;
				UI = mapDataMgrToCtrlType[mgr.GetType()]();

				foreach(Data.AbstractChildMgr cmgrCur in mgr.ChildMgrByName.Values)
					ocChildren.Add(new(cmgrCur));
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
			private static readonly System.Collections.Generic.Dictionary<System.Type, System.Func<VisualPrefsTabCtrl>> mapDataMgrToCtrlType =
				new();

			private readonly System.Collections.ObjectModel.ObservableCollection<VisualPrefsTreeData> ocChildren =
				new();
		#endregion

		#region Properties
			public Data.AbstractMgr Mgr
			{
				get;

				private init;
			}

			public VisualPrefsTabCtrl UI
			{
				get;

				private init;
			}
		#endregion

		#region Methods
			public static void RegisterDataEditorCtrlType(in System.Type typeOfMgr, in System.Func<VisualPrefsTabCtrl> typeOfEditorCtrl)
			{
				if(!typeOfMgr.IsDerivedFrom(typeof(Data.AbstractMgr)))
					throw new System.ArgumentException("When calling BestChat.Platform.TreeData.VisualTreeData.RegisterDataEditorCtrlType, the" +
						$" type specified in {typeOfEditorCtrl} must be a BestChat preference manager, either child or main.",
						nameof(typeOfEditorCtrl));

				if(mapDataMgrToCtrlType.ContainsKey(typeOfMgr))
					throw new System.ArgumentException("Chat.Platform.TreeData.VisualTreeData.RegisterDataEditorCtrlType was already called " +
						"with a manager type that was already in the system.", nameof(typeOfMgr));

				mapDataMgrToCtrlType[typeOfMgr] = typeOfEditorCtrl;
			}
		#endregion

		#region Event Handlers
		#endregion
	}
}