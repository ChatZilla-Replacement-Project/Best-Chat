// Ignore Spelling: evt

namespace BestChat.ClientConversation
{
	public class ClientConversation : Platform.Conversations.AbstractConversation, Platform.Conversations
		.IGroup, Platform.TreeData.VisualTreeData.IChildOwner
	{
		#region Constructors & Deconstructors
			private ClientConversation() : base(Resources.strClientConversationViewName, Resources
				.strClientConversationViewDesc)
			{
				IRC.Data.Defs.UserNetwork unLibera = new(IRC.Data.Defs.NetworkMgr.mgr
					.AllItems["Libera"]);
				IRC.Data.Defs.UserNetworkMgr.mgr.Add(unLibera);
				IRC.Data.ActiveNetwork anLibera = new(unLibera);

				#if DemoMode
					ocUnsortedChildren.Add(anLibera);
					mapAllChildrenByName[anLibera.Name] = anLibera;

					RecordEvent(new ClientEventInfo(ClientEventType.Hello, Resources
						.strClientEventWelcomeToBestChat));
					RecordEvent(new ClientEventInfo(ClientEventType.Hello, Resources
						.strClientEventHelpInfo));

					System.Text.Json.JsonDocument doc = System.Text.Json.JsonDocument.Parse(client
						.GetStreamAsync("https://github.com/ChatZilla-Replacement-Project/JSON-Data/raw/main" +
						"/Sample%20Data/Sample%20Client%20log.json").Result, jdo);

					if(doc.RootElement.ValueKind == System.Text.Json.JsonValueKind.Array)
						foreach(System.Text.Json.JsonElement elementCur in doc.RootElement.EnumerateArray())
							if(elementCur.ValueKind == System.Text.Json.JsonValueKind.Object)
								RecordEvent(new ClientEventInfo(elementCur.GetProperty(nameof(ClientEventInfo.Type))
									.GetString() switch
									{
										"hello" => ClientEventType.Hello,
										"info" => ClientEventType.Info,
										_ => throw new System.Exception("Sample log from Internet has an unknown event " +
											"type"),
									}, elementCur.GetProperty(nameof(ClientEventInfo.DescForEvt)).GetString() ?? throw new
									System.Exception("Sample log from Internet is missing the DescForEvent " +
									"field.")));
				#endif
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
			private static readonly System.Net.Http.HttpClient client = Platform.HttpClientOwner.HttpClientOwner
				.hc;

			public static readonly ClientConversation instance = new();


			private static readonly System.Text.Json.JsonDocumentOptions jdo = new()
			{
				AllowTrailingCommas = true,
				CommentHandling = System.Text.Json.JsonCommentHandling.Skip,
			};

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