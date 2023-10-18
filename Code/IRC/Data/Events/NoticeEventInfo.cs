namespace BestChat.IRC.Data.Events
{
	[System.ComponentModel.ImmutableObject(true)]
	public class NoticeEventInfo : Platform.Conversations.AbstractEventInfo<Types.NoticeEventType, Types
		.NoticeEventType.Types>
	{
		#region Constructors & Deconstructors
			internal NoticeEventInfo(in Types.NoticeEventType type, in string strDescForEvent) : base(type,
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