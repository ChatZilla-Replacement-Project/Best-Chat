// Ignore Spelling: Ctrls Ctrl gvc

namespace BestChat.IRC.Global.View.Ctrls
{
	public abstract class AbstractConversationTabCtrl : GUI.Ctrls.VisualConversationTabCtrl
	{
		#region Constructors & Deconstructors
			protected AbstractConversationTabCtrl(in Platform.Conversations.IGroupViewOrConversation gvc, in
				string strLocalizedLongDesc) : base(gvc, strLocalizedLongDesc)
			{
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
		#endregion

		#region Properties
			public abstract bool ShouldModeBarBeShown
			{
				get;
			}
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}