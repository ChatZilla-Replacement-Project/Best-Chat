// Ignore Spelling: cet

namespace BestChat.ClientConversation
{
	public class ClientEventType : Platform.Conversations.AbstractEventType<ClientEventType.Types>
	{
		#region Constructors & Deconstructors
			private ClientEventType(in Types type, in string strDescOfVal) : base(type, strDescOfVal)
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
			public enum Types
			{
				hello,
				info
			}
		#endregion

		#region Members
			public static readonly ClientEventType cetHello = new(Types.hello, Resources
				.strClientEventTypeNameHello);

			public static readonly ClientEventType cetInfo = new(Types.info, Resources
				.strClientEventTypeNameInfo);
		#endregion

		#region Properties
			public static ClientEventType Hello => cetHello;

			public static ClientEventType Info => cetInfo;
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}