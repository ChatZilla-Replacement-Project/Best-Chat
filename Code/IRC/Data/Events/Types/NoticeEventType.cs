namespace BestChat.IRC.Data.Events.Types
{
	[System.ComponentModel.ImmutableObject(true)]
	public class NoticeEventType : Platform.Conversations.AbstractEventType<NoticeEventType.Types>
	{
		#region Constructors & Deconstructors
			[System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove " +
				"unused private members", Justification = "No known event types of this variety come up with " +
				"yet")]
			private NoticeEventType(in Types type, in string strDescOfVal) : base(type, strDescOfVal)
			{
			}
		#endregion

		#region Constants
		#endregion

		#region Helper Types
			public enum Types
			{
			}
		#endregion

		#region Properties
		#endregion
	}
}