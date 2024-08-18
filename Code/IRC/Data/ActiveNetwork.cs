// Ignore Spelling: unet Chans cgroup evt

namespace BestChat.IRC.Data
{
	using System.Linq;
	using Util.Ext;

	public class ActiveNetwork : AbstractConversation, Platform.Conversations.IGroup, System.ComponentModel
		.INotifyPropertyChanged, Platform.TreeData.VisualTreeData.IChildOwner
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

					#if DemoMode
						// TODO: Replace the list of channels with a real list loaded from storage
						AddChild(new Chan(this, "##space"));
						AddChild(new Chan(this, "#best-chat"));

						// TODO: Replace the list of users with a real list loaded from storage
						AddChild(new ConversationWithRemoteUser(this, new(this, "Peter",
							mapModesOnUser.Values, System.Array.Empty<Chan>())));
						AddChild(new ConversationWithRemoteUser(this, new(this, "Micheal",
							mapModesOnUser.Values, System.Array.Empty<Chan>())));

						System.Text.Json.JsonDocument doc = System.Text.Json.JsonDocument.Parse(client
							.GetStreamAsync("https://github.com/ChatZilla-Replacement-Project/JSON-Data/blob" +
							"/main/Sample%20Data/Sample%20Libera%20Log.json").Result, jdo);

						if(doc.RootElement.ValueKind == System.Text.Json.JsonValueKind.Array)
							foreach(System.Text.Json.JsonElement elementCur in doc.RootElement.EnumerateArray())
								if(elementCur.ValueKind == System.Text.Json.JsonValueKind.Object)
									switch(elementCur.GetProperty(nameof(Type)).GetString())
									{
										case "action":
											throw new System.Exception("Unexpected action event type in a network tab.");

										case "post":
											throw new System.Exception("Posts aren't valid in network logs, but the " +
												"sample data has some.");

										case "notice":
											switch(elementCur.GetProperty("SubType").GetString())
											{
												case nameof(Events.Types.NoticeEventType.Types.connectAttemptInProgress):
													RecordEvent(new Events.NoticeEventInfo
														.ConnectAttemptInProgressNoticeEventInfo(Name));

													break;

												default:
													throw new System.Exception("Unknown event notice subtype in network log " +
														"sample data");
											}
											break;

										default:
											throw new System.Exception("Unknown event type in network log sample data");
									}
					#else
					#endif
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
			#if DemoMode
				private static readonly System.Net.Http.HttpClient client = Platform.HttpClientOwner
					.HttpClientOwner.hc;

				private static readonly System.Text.Json.JsonDocumentOptions jdo = new()
				{
					AllowTrailingCommas = true,
					CommentHandling = System.Text.Json.JsonCommentHandling.Skip,
				};
			#endif


			public readonly Defs.UserNetwork unetDef;

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


			private readonly System.Collections.Generic.SortedDictionary<string, Platform.Conversations
				.IGroupViewOrConversation> mapConversationsByPath = new();

			private readonly System.Collections.ObjectModel.ObservableCollection<Platform.Conversations
				.IGroupViewOrConversation> ocAllConversations = new
				();
		#endregion

		#region Properties
			public Defs.UserNetwork Def => unetDef;

			// TODO: We need a way to update the nick on this user.
			public RemoteUser UserInfo => ru;

			public System.Collections.Generic.IReadOnlyDictionary<char, Defs.Mode<Defs.BoolModeState, Defs
				.BoolModeStates>> AllModesOnUser => mapModesOnUser;

			public System.Uri ConnectedTo => uriConnectedTo;

			public System.Collections.Generic.IReadOnlyDictionary<string, RemoteUser> AllKnownUsersByNick =>
				mapChanMembersByNick;

			public System.Collections.Generic.IReadOnlyDictionary<string, Platform.Conversations
				.IGroupViewOrConversation> ChildrenByName => mapConversationsByPath;

			public System.Collections.Generic.IEnumerable<Platform.Conversations.IGroupViewOrConversation>
				UnsortedChildren => ocAllConversations;

			System.Collections.Generic.IEnumerable<Platform.TreeData.VisualTreeData.IItemInfo> Platform.TreeData
				.VisualTreeData.IChildOwner.Children => ocAllConversations;


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

			private void AddChild(Platform.Conversations.IGroupViewOrConversation gvcToBeAdded)
			{
				mapConversationsByPath[gvcToBeAdded.Path] = gvcToBeAdded;

				ocAllConversations.Add(gvcToBeAdded);
			}
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

		private readonly System.Collections.Generic.SortedDictionary<string, ActiveNetwork>
			mapAllActiveNetworksByName = new();

		private readonly System.Collections.ObjectModel.ObservableCollection<ActiveNetwork>
			ocUnsortedAllActiveNetworks = new();

		public System.Collections.Generic.IReadOnlyDictionary<string, ActiveNetwork> AllActiveNetworksByName
			=> mapAllActiveNetworksByName;

		public System.Collections.Generic.IEnumerable<ActiveNetwork> UnsortedAllActiveNetworks =>
			ocUnsortedAllActiveNetworks;
	}
}