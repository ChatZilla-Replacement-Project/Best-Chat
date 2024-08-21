// Ignore Spelling: gvc Ctrl

namespace BestChat.IRC.ProtocolModule.GUI
{
	public class ProtocolGuiDef : ProtocolDef
	{
		public static readonly ProtocolGuiDef instance = new();

		public void RegisterPrefCtrlMap()
		{
			//Platform.Prefs.Ctrls.VisualPrefsTreeData.RegisterDataEditorCtrlType(typeof(Data.Prefs.PrefsMgr), )
		}

		public BestChat.GUI.Ctrls.AbstractVisualConversationCtrl MakeConversationCtrl(Platform.Conversations
			.IGroupViewOrConversation gvcWhatWeNeedCtrlFor) => new General.View.ConversationViewCtrl(gvcWhatWeNeedCtrlFor);

		public void Init(Platform.Prefs.Data.AbstractMgr mgrRoot) => Prefs.Data.Prefs.Init(mgrRoot);
	}
}