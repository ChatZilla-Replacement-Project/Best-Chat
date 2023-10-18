namespace BestChat.IRC.Data.Events
{
	[System.ComponentModel.ImmutableObject(true)]
	public class ActionEventInfo : Platform.Conversations.AbstractEventInfo<Types.ActionEventType, Types
		.ActionEventType.Types>
	{
		#region Constructors & Deconstructors
			internal ActionEventInfo(in Types.ActionEventType type, in string strDescForEvent) : base(type,
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