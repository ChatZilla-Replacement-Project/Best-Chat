// Ignore Spelling: dt

using BestChat.Util.Ext;

namespace BestChat.IRC.Data.Events
{
	[System.ComponentModel.ImmutableObject(true)]
	public abstract class NoticeEventInfo : Platform.Conversations.AbstractEventInfo<Types.NoticeEventType,
		Types.NoticeEventType.Types>
	{
		#region Constructors & Deconstructors
			protected internal NoticeEventInfo(in Types.NoticeEventType type, System.DateTime? dtWhenItHappened
				= null) : base(type, dtWhenItHappened ?? System.DateTime.Now)
			{
			}
		#endregion

		#region Helper Types
			public class InfoNoticeEventInfo : NoticeEventInfo
			{
				internal InfoNoticeEventInfo(in string strDescOfEvent, in System.DateTime? dtWhenItHappened =
					null) : base(Types.NoticeEventType.Info, dtWhenItHappened) => this.strDescOfEvent =
					strDescOfEvent;

				public readonly string strDescOfEvent;

				public override string DescForEvt => strDescOfEvent;
			}

			public class ConnectAttemptInProgressNoticeEventInfo : NoticeEventInfo
			{
				internal ConnectAttemptInProgressNoticeEventInfo(in string strNetName, in System.DateTime?
					dtWhenItHappened = null) : base(Types.NoticeEventType.Info, dtWhenItHappened) => this.strNetName
					= strNetName;

				public readonly string strNetName;

				public override string DescForEvt => Resources.strNoticeEventTypeConnectionAttemptInProgressDesc
					.Fmt(strNetName);
			}
		#endregion
	}
}