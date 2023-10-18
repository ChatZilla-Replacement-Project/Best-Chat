// Ignore Spelling: unet Chans cgroup evt

namespace BestChat.IRC.Data
{
	using Util.Ext;

	public class ActiveNetwork : Platform.Conversations.AbstractConversation, Platform.Conversations.IGroup,
		System.ComponentModel.INotifyPropertyChanged, Platform.TreeData.VisualTreeData.IChildOwner
	{
		#region Constructors & Deconstructors
			#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
				public ActiveNetwork(in Defs.UserNetwork unetDef) : base(unetDef.Name, Resources
					.strNetworkNameDescForTree.Fmt(unetDef.Name))
				{
					this.unetDef = unetDef;

					// TODO: Figure out how to actually connect.

					// TODO: Determine how to get the user's real nick
					ru = new(this, "UserNick", mapModesOnUser.Values, System.Array.Empty<Chan>()); 


					// TODO: Get the real modes for the user on this network
					foreach(Defs.UserMode cmdCur in unetDef.UserModesByModeChar.Values)
					{
						Defs.Mode<Defs.BoolModeState, Defs.BoolModeStates> modeNew = new
						(cmdCur, Defs.BoolModeState.off);

						mapModesOnUser[cmdCur.ModeChar] = modeNew;

						modeNew.evtStateChanged += OnStateOfModeChanged;
					}

					mapConversationGroupsByName["Channels"] = cgroupChannels = new
					 (GroupOfConversations.Types.channels, Resources.strConversationGroupTypeChannels, Resources
						.strConversationGroupChannelsDesc, new Chan(this, "##space"), new Chan(this,
						"#best-chat"));
					cgroupChannels.CollectionChanged += OnChildGroupChildrenChanged;

					mapConversationGroupsByName["Users"] = cgroupRemoteUsers = new
						(GroupOfConversations.Types.users, Resources.strConversationGroupTypeRemoteUsers, Resources
						.strConversationGroupRemoteUsersDesc, new ConversationWithRemoteUser(this, new
						(this, "peter", mapModesOnUser.Values, System.Array.Empty<Chan>())));
					cgroupRemoteUsers.CollectionChanged += OnChildGroupChildrenChanged;
				}
			#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

			~ActiveNetwork() => evtDieing?.Invoke(this);
		#endregion

		#region Delegates
		#endregion

		#region Events
			public override event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;

			public event System.Collections.Specialized.NotifyCollectionChangedEventHandler?
				CollectionChanged;

			public override event Platform.Common.IDieable.OnDieing? evtDieing;
		#endregion

		#region Constants
		#endregion

		#region Helper Types
		#endregion

		#region Members
			public readonly Defs.UserNetwork unetDef;

			private readonly System.Collections.Generic.SortedDictionary<string, Chan> mapChansByName = new
				();

			public readonly RemoteUser ru;

			private readonly System.Collections.Generic.SortedDictionary<char, Defs.Mode<Defs.BoolModeState,
				Defs.BoolModeStates>> mapModesOnUser = new();

			// TODO: Remove this attribute once the field is functional
			[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly " +
				"modifier", Justification = "Field not yet implemented")]
			private System.Uri uriConnectedTo;

			// TODO: We need a way to update this map when the remote user's nick changes.
			private readonly System.Collections.Generic.SortedDictionary<string, RemoteUser>
				mapChanMembersByNick = new();


			private readonly System.Collections.Generic.SortedDictionary<string, GroupOfConversations>
				mapConversationGroupsByName = new();

			private readonly System.Collections.ObjectModel.ObservableCollection<GroupOfConversations>
				ocUnsortedConversationGroups;


			public readonly GroupOfConversations cgroupChannels;

			public readonly GroupOfConversations cgroupRemoteUsers;
		#endregion

		#region Properties
			public Defs.UserNetwork Def => unetDef;

			public System.Collections.Generic.IReadOnlyDictionary<string, Chan> AllChansByName =>
				mapChansByName;

			// TODO: We need a way to update the nick on this user.
			public RemoteUser UserInfo => ru;

			public System.Collections.Generic.IReadOnlyDictionary<char, Defs.Mode<Defs.BoolModeState, Defs
				.BoolModeStates>> AllModesOnUser => mapModesOnUser;

			public System.Uri ConnectedTo => uriConnectedTo;

			public System.Collections.Generic.IReadOnlyDictionary<string, RemoteUser> AllKnownUsersByNick =>
				mapChanMembersByNick;

			public System.Collections.Generic.IReadOnlyDictionary<string, Platform.Conversations
				.IGroupViewOrConversation> ChildrenByName => (System.Collections.Generic
				.IReadOnlyDictionary<string, Platform.Conversations
				.IGroupViewOrConversation>)mapConversationGroupsByName;

			public System.Collections.Generic.IEnumerable<Platform.Conversations.IGroupViewOrConversation>
				UnsortedChildren => ocUnsortedConversationGroups;

			System.Collections.Generic.IEnumerable<Platform.TreeData.VisualTreeData.IItemInfo> Platform.TreeData
				.VisualTreeData.IChildOwner.Children => ocUnsortedConversationGroups;


			public override string ProperName => unetDef.Name;

			public override string SafeName => System.Web.HttpUtility.UrlPathEncode(ProperName);

			public override string Path => unetDef.Name;

			public override string LocalizedName => ProperName;

			public override string Icon => "🖥️";


			public override Platform.Conversations.IViewOrConversation.Types Type => Platform.Conversations
				.IViewOrConversation.Types.group;
		#endregion

		#region Methods
			protected override void FirePropChanged(string strWhichProp) => PropertyChanged?.Invoke(this, new
				(strWhichProp));
		#endregion

		#region Event Handlers
			private void OnStateOfModeChanged(Defs.Mode<Defs.BoolModeState, Defs.BoolModeStates> modeSender,
				Defs.BoolModeState stateOld, Defs.BoolModeState stateNew)
			{
				// TODO: Attempt to change the mode on the network
			}
			private void OnChildGroupChildrenChanged(object? sender, System.Collections.Specialized
				.NotifyCollectionChangedEventArgs ea) => CollectionChanged?.Invoke(this, ea);
		#endregion
	}

	public class MgrForActiveNetworks
	{
		private MgrForActiveNetworks()
		{
		}

		public static readonly MgrForActiveNetworks instance = new();

		private System.Collections.Generic.SortedDictionary<string, ActiveNetwork>
			mapAllActiveNetworksByName = new();

		private readonly System.Collections.ObjectModel.ObservableCollection<ActiveNetwork>
			ocUnsortedAllActiveNetworks = new();

		public System.Collections.Generic.IReadOnlyDictionary<string, ActiveNetwork> AllActiveNetworksByName
			=> mapAllActiveNetworksByName;

		public System.Collections.Generic.IEnumerable<ActiveNetwork> UnsortedAllActiveNetworks =>
			ocUnsortedAllActiveNetworks;
	}
}