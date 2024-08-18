// Ignore Spelling: dt Evt

namespace BestChat.ClientConversation
{
	public class ClientEventInfo : Platform.Conversations.AbstractEventInfo<ClientEventType,
		ClientEventType.Types>
	{
		#region Constructors & Deconstructors
			public ClientEventInfo(in ClientEventType type, in string strDescForEvt, in System
				.DateTime? dtWhenItHappened = null) : base(type, dtWhenItHappened ?? System
				.DateTime.Now) => this.strDescForEvt = strDescForEvt;
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
			public readonly string strDescForEvt;

		#endregion

		#region Properties
			public override string DescForEvt => strDescForEvt;
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}