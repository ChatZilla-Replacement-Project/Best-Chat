namespace BestChat.IRC.Data.Events
{
	[System.ComponentModel.ImmutableObject(true)]
	public class PostEventInfo : Platform.Conversations.AbstractEventInfo<Types.PostEventType, Types
		.PostEventType.Types>
	{
		#region Constructors & Deconstructors
			internal PostEventInfo(in Types.PostEventType type, in string strDescForEvent) : base(type,
				strDescForEvent)
			{
			}
		#endregion

		#region Members
		#endregion

		#region Properties
		#endregion
	}
}