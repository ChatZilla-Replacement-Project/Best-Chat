// Ignore Spelling: evt

namespace BestChat.IRC.Data
{
	public class GroupOfConversations : Platform.Conversations.IGroup, Platform.TreeData.VisualTreeData
		.IChildOwner
	{
		#region Constructors & Deconstructors
			public GroupOfConversations(in Types type, in string strName, in string strLongDesc, params Platform
				.Conversations.IGroupViewOrConversation[] childrenToAdd)
			{
				this.type = type;
				this.strName = strName;
				this.strLongDesc = strLongDesc;

				foreach(Platform.Conversations.IGroupViewOrConversation viewCur in childrenToAdd)
				{
					mapChildrenByName[viewCur.Name] = viewCur;
					ocUnsortedChildren.Add(viewCur);

					if(viewCur is Platform.Conversations.IGroup groupCur)
						groupCur.CollectionChanged += OnChildChildrenChanged;
					viewCur.evtDieing += OnChildDieing;
				}
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
			public event System.Collections.Specialized.NotifyCollectionChangedEventHandler? CollectionChanged;

			public event Platform.Common.IDieable.OnDieing? evtDieing;
		#endregion

		#region Constants
		#endregion

		#region Helper Types
			public enum Types
			{
				users,
				channels,
			}
		#endregion

		#region Members
			public readonly Types type;

			public readonly string strName;

			public readonly string strLongDesc;

			private readonly System.Collections.Generic.Dictionary<string, Platform.Conversations
				.IGroupViewOrConversation> mapChildrenByName = new();

			private readonly System.Collections.ObjectModel.ObservableCollection<Platform.Conversations
				.IGroupViewOrConversation> ocUnsortedChildren = new();
		#endregion

		#region Properties
			public Types Type => type;

			public string Name => strName;

			public string ProperName => strName;

			public string SafeName => strName;

			public string LongDesc => strLongDesc;

			public string LocalizedName => strName;

			public string LocalizedLongDesc => strLongDesc;

			public string Path => strName;

			public string Icon => "📚";

			public bool CanBeSelected => false;


			public System.Collections.Generic.IReadOnlyDictionary<string, Platform.Conversations
				.IGroupViewOrConversation> ChildrenByName => mapChildrenByName;

			public System.Collections.Generic.IEnumerable<Platform.Conversations.IGroupViewOrConversation>
				UnsortedChildren => ocUnsortedChildren;

			System.Collections.Generic.IEnumerable<Platform.TreeData.VisualTreeData.IItemInfo> Platform.TreeData
				.VisualTreeData.IChildOwner.Children => ocUnsortedChildren;
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
			private void OnChildChildrenChanged(object? objSender, System.Collections.Specialized
				.NotifyCollectionChangedEventArgs ea) => CollectionChanged?.Invoke(this, ea);


			private void OnChildDieing(Platform.Common.IDieable dieing)
			{
				if(dieing is Platform.Conversations.IGroupViewOrConversation igvDieing && mapChildrenByName
					.ContainsKey(igvDieing.Name))
				{
					mapChildrenByName.Remove(igvDieing.Name);
					ocUnsortedChildren.Remove(igvDieing);
				}
			}
		#endregion
	}
}