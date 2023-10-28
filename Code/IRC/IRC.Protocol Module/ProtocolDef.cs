// Ignore Spelling: Ctrl cmgr gvc vgc Prefs

namespace BestChat.IRC.Protocol_Module
{
	public class ProtocolDef : ProtocolMgr.GUI.ProtocolGuiMgr.IProtocolGuiDef
	{
		private ProtocolDef()
		{
			TopLevelViewGroupOrConversation = null;
			ProtocolMgrForRootPrefObj = null;
		}

		public static readonly ProtocolDef instance = new();

		public void Init(Platform.Prefs.Data.AbstractMgr mgrParent, Platform.Conversations
			.IGroupViewOrConversation vgcTopLevel)
		{
			ProtocolMgrForRootPrefObj = Data.Prefs.PrefsMgr.Init(mgrParent);

			TopLevelViewGroupOrConversation = vgcTopLevel;
		}

		public Platform.Prefs.Ctrls.VisualPrefsTabCtrl MakePrefsCtrl(Platform.Prefs.Data.AbstractChildMgr
			cmgrThatWeNeedCtrlFor) => cmgrThatWeNeedCtrlFor is Data.Prefs.NetworkPrefs ? new Global.View
			.NetworkPrefVisualTabCtrl(cmgrThatWeNeedCtrlFor) : cmgrThatWeNeedCtrlFor is Data.Prefs.ChanPrefs ?
			new Global.View.ChanPrefVisualTabCtrl(cmgrThatWeNeedCtrlFor) : cmgrThatWeNeedCtrlFor is Data.Prefs
			.RemoteUserPrefs ? new Global.View.RemoteUserPrefVisualTabCtrl(cmgrThatWeNeedCtrlFor) : throw new
			System.InvalidProgramException("Unknown type of conversation, group, or view in the IRC module " +
			"system.");

		public GUI.Ctrls.VisualConversationTabCtrl MakeConversationCtrl(Platform.Conversations
			.IGroupViewOrConversation gvcWhatWeNeedCtrlFor) => gvcWhatWeNeedCtrlFor is Data.ActiveNetwork anet ?
			new Global.View.NetworkConversationTabCtrl(anet) : gvcWhatWeNeedCtrlFor is Data.Chan chan ? new
			Global.View.ChanConversationTabCtrl(chan) : gvcWhatWeNeedCtrlFor is Data.ConversationWithRemoteUser
			cru ? new Global.View.RemoteUserConversationTabCtrl(cru) : throw new System
			.InvalidProgramException("Unknown type of conversation, group, or view in the IRC module "
			+ "system.");

		public string Name => Resources.strModuleTitle;

		public string Publisher => Resources.strModulePublisher;

		public System.Uri Homepage => new("https://github.com/ChatZilla-Replacement-Project");

		public System.Uri PublisherHomepage => new("https://github.com/ChatZilla-Replacement-" +
			"Project");

		public Platform.Prefs.Data.AbstractChildMgr? ProtocolMgrForRootPrefObj
		{
			get;

			private set;
		}

		public Platform.Conversations.IGroupViewOrConversation? TopLevelViewGroupOrConversation
		{
			get;

			private set;
		}
	}
}