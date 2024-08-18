// Ignore Spelling: Ctrls Ctrl gvc

namespace BestChat.GUI.Ctrls
{
	public abstract class AbstractVisualConversationCtrl : AbstractVisualCtrl
	{
		#region Constructors & Deconstructors
			public AbstractVisualConversationCtrl(in Platform.Conversations.IGroupViewOrConversation gvc) :
				base(gvc.ProperName, gvc.LongDesc)
			{
				this.gvc = gvc;

				DataContext = gvc;
			}
		#endregion

		#region Constants
		#endregion

		#region Members
			public readonly Platform.Conversations.IGroupViewOrConversation gvc;

			private readonly ConversationDataListView lvCtnts = new();
		#endregion

		#region Properties
		#endregion

		#region Methods
			protected override void OnInitialized(System.EventArgs e)
			{
				base.OnInitialized(e);

				Ctnts = lvCtnts;

				
			}
		#endregion

		#region Event Handlers
		#endregion
	}
}