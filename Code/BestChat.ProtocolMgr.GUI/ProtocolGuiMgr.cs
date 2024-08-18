// Ignore Spelling: Ctrl gvc Prefs cmgr Defs

namespace BestChat.ProtocolMgr.GUI
{
	public sealed class ProtocolGuiMgr : ProtocolMgr
	{
		#region Constructors & Deconstructors
			public ProtocolGuiMgr()
			{
			}

			static ProtocolGuiMgr()
			{
				mgr = new();
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
		#endregion

		#region Constants
		#endregion

		#region Helper Types
			public interface IProtocolGuiDef : ProtocolMgr.IProtocolDef
			{
				public void RegisterPrefCtrlMap();

				public BestChat.GUI.Ctrls.AbstractVisualConversationCtrl MakeConversationCtrl(Platform
					.Conversations.IGroupViewOrConversation gvcWhatWeNeedCtrlFor);
			}
		#endregion

		#region Members
			private static readonly ProtocolGuiMgr mgr;
		#endregion

		#region Properties
			public new System.Collections.Generic.IReadOnlyDictionary<string, IProtocolGuiDef>
				AllProtocolDefsByName => (System.Collections.Generic.IReadOnlyDictionary<string,
				IProtocolGuiDef>)base.AllProtocolDefsByName;

		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}