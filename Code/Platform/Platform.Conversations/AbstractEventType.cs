namespace BestChat.Platform.Conversations
{
	[System.ComponentModel.ImmutableObject(true)]
	public class AbstractEventType<EnumTypeAssociatedWithThisEventType>
		where EnumTypeAssociatedWithThisEventType : struct, System.Enum
	{
		#region Constructors & Deconstructors
			protected AbstractEventType(in EnumTypeAssociatedWithThisEventType val, in string strDescOfVal)
			{
				this.val = val;
				this.strDescOfVal = strDescOfVal;
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
			public readonly EnumTypeAssociatedWithThisEventType val;

			public readonly string strDescOfVal;
		#endregion

		#region Properties
			public EnumTypeAssociatedWithThisEventType Val => val;

			public string DescOfVal => strDescOfVal;
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}