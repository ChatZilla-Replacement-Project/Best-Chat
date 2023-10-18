// Ignore Spelling: Ctrls Ctrl

namespace BestChat.GUI.Ctrls
{
	public class VisualConversationTabCtrl : AbstractVisualTabCtrl
	{
		#region Constructors & Deconstructors
			public VisualConversationTabCtrl(in Platform.Conversations.IGroupViewOrConversation conversation, in
				string strLocalizedLongDesc) : base(conversation.ProperName, strLocalizedLongDesc)
			{
			}
		#endregion
	}
}