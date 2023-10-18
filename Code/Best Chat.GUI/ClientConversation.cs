// Ignore Spelling: evt

using BestChat.IRC.Data;

namespace BestChat.GUI
{
	public class ClientConversation : Platform.Conversations.AbstractConversation, Platform.Conversations
		.IGroup, Platform.TreeData.VisualTreeData.IChildOwner
	{
		#region Constructors & Deconstructors
			private ClientConversation() : base(Resources.strClientConversationViewName, Resources
				.strClientConversationViewDesc)
			{
				IRC.Data.Defs.UserNetwork unLibera = new(IRC.Data.Defs.NetworkMgr.mgr.AllItems["Libera"]);
				IRC.Data.Defs.UserNetworkMgr.mgr.Add(unLibera);
				ActiveNetwork anLibera = new(unLibera);

				ocUnsortedChildren.Add(anLibera);
				mapAllChildrenByName[anLibera.Name] = anLibera;
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
			public override event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;

			public event System.Collections.Specialized.NotifyCollectionChangedEventHandler? CollectionChanged;

			public override event Platform.Common.IDieable.OnDieing? evtDieing;
		#endregion

		#region Constants
		#endregion

		#region Helper Types
		#endregion

		#region Members
			public static readonly ClientConversation instance = new();

			private readonly System.Collections.Generic.SortedDictionary<string, Platform.Conversations
				.IGroupViewOrConversation> mapAllChildrenByName = new();

			private readonly System.Collections.ObjectModel.ObservableCollection<Platform.Conversations
				.IGroupViewOrConversation> ocUnsortedChildren = new();
		#endregion

		#region Properties
			public override string ProperName => Resources.strClientConversationViewName;

			public override string SafeName => Resources.strClientConversationViewName;

			public override string Path => Resources.strClientConversationViewName;

			public override string LocalizedName => Resources.strClientConversationViewName;

			public override string Icon => "🌐";

			public override Platform.Conversations.IViewOrConversation.Types Type => Platform.Conversations
				.IViewOrConversation.Types.client;


			public System.Collections.Generic.IReadOnlyDictionary<string, Platform.Conversations
				.IGroupViewOrConversation> ChildrenByName => mapAllChildrenByName;

			public System.Collections.Generic.IEnumerable<Platform.Conversations.IGroupViewOrConversation>
				UnsortedChildren => ocUnsortedChildren;

			System.Collections.Generic.IEnumerable<Platform.TreeData.VisualTreeData.IItemInfo> Platform.TreeData
				.VisualTreeData.IChildOwner.Children => ocUnsortedChildren;
		#endregion

		#region Methods
			protected override void FirePropChanged(string strPropName) => PropertyChanged?.Invoke(this, new
				(strPropName));
		#endregion

		#region Event Handlers
		#endregion
	}
}