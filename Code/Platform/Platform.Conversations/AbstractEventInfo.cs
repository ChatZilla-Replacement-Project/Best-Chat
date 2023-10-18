namespace BestChat.Platform.Conversations
{
	public interface IEventInfo
	{
		public string DescForEvent
		{
			get;
		}
	}

	[System.ComponentModel.ImmutableObject(true)]
	public abstract class AbstractEventInfo<EventType, EnumForEventType> : IEventInfo
		where EnumForEventType : struct, System.Enum
		where EventType : AbstractEventType<EnumForEventType>
	{
		#region Constructors & Deconstructors
			protected AbstractEventInfo(in EventType type, string strDescForEvent)
			{
				this.type = type;
				this.strDescForEvent = strDescForEvent;
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
			public readonly EventType type;

			public readonly string strDescForEvent;
		#endregion

		#region Properties
			public EventType Type => type;

			public string DescForEvent => strDescForEvent;
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}