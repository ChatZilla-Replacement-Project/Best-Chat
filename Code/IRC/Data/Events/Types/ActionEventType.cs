// Ignore Spelling: aet Unban Opped Deopped Dehalf

namespace BestChat.IRC.Data.Events.Types
{
	[System.ComponentModel.ImmutableObject(true)]
	public class ActionEventType : Platform.Conversations.AbstractEventType<ActionEventType
		.Types>
	{
		#region Constructors & Deconstructors
			private ActionEventType(in Types type, in string strDescOfVal) : base(type, strDescOfVal)
			{
			}
		#endregion

		#region Constants
			public static readonly ActionEventType aetKickOfUser = new(Types.kickOfUser, Resources
				.strActionEventTypeKickOfUserDesc);

			public static readonly ActionEventType aetBanOfUser = new(Types.banOfUser, Resources
				.strActionEventTypeBanOfUserDesc);

			public static readonly ActionEventType aetUnbanOfUser = new(Types.unbanOfUser, Resources
				.strActionEventTypeUnbanOfUserDesc);

			public static readonly ActionEventType aetQuietOfUser = new(Types.quietOfUser, Resources
				.strActionEventTypeQuietOfUserDesc);

			public static readonly ActionEventType aetUnquietOfUser = new(Types.unquietOfUser,
				Resources.strActionEventTypeUnquietOfUserDesc);

			public static readonly ActionEventType aetJoin = new(Types.join, Resources
				.strActionEventTypeJoinDesc);

			public static readonly ActionEventType aetQuit = new(Types.quit, Resources
				.strActionEventTypeQuitDesc);

			public static readonly ActionEventType aetTopicChanged = new(Types.topicChanged,
				Resources.strActionEventTypeTopicChangedDesc);

			public static readonly ActionEventType aetChanModeAdded = new(Types.chanModeAdded,
				Resources.strActionEventTypeChanModeAddedDesc);

			public static readonly ActionEventType aetChanModeRemoved = new(Types.chanModeRemoved,
				Resources.strActionEventTypeChanModeRemovedDesc);

			public static readonly ActionEventType aetChanModeAddedAndRemoved = new(Types
				.chanModeAddedAndRemoved, Resources.strActionEventTypeChanModeAddedAndRemovedDesc);

			public static readonly ActionEventType aetUserVoiced = new(Types.userVoiced, Resources
				.strActionEventTypeUserVoicedDesc);

			public static readonly ActionEventType aetUserDevoiced = new(Types.userDevoiced,
				Resources.strActionEventTypeUserDevoicedDesc);

			public static readonly ActionEventType aetUserOpped = new(Types.userOpped, Resources
				.strActionEventTypeUserOppedDesc);

			public static readonly ActionEventType aetUserDeopped = new(Types.userDeopped, Resources
				.strActionEventTypeUserDeoppedDesc);

			public static readonly ActionEventType aetUserHalfOpped = new(Types.userHalfOpped,
				Resources.strActionEventTypeUserHalfOppedDesc);

			public static readonly ActionEventType aetUserDehalfOpped = new(Types.userDehalfOpped,
				Resources.strActionEventTypeUserDehalfOppedDesc);

			public static readonly ActionEventType aetNickOfUserChanged = new(Types
				.nickOfUserChanged, Resources.strActionEventTypeNickOfUserChangedDesc);
		#endregion

		#region Helper Types
			public enum Types
			{
				kickOfUser,
				banOfUser,
				unbanOfUser,
				quietOfUser,
				unquietOfUser,
				join,
				quit,
				part,
				topicChanged,
				chanModeAdded,
				chanModeRemoved,
				chanModeAddedAndRemoved,
				userVoiced,
				userDevoiced,
				userOpped,
				userDeopped,
				userHalfOpped,
				userDehalfOpped,
				nickOfUserChanged,
			}
		#endregion

		#region Properties
			public static ActionEventType KickOfUser => aetKickOfUser;

			public static ActionEventType BanOfUser => aetBanOfUser;

			public static ActionEventType UnbanOfUser => aetUnbanOfUser;

			public static ActionEventType QuietOfUser => aetQuietOfUser;

			public static ActionEventType UnquietOfUser => aetUnquietOfUser;

			public static ActionEventType Join => aetJoin;

			public static ActionEventType Quit => aetQuit;

			public static ActionEventType TopicChanged => aetTopicChanged;

			public static ActionEventType ChanModeAdded => aetChanModeAdded;

			public static ActionEventType ChanModeRemoved => aetChanModeRemoved;

			public static ActionEventType ChanModeAddedAndRemoved => aetChanModeAddedAndRemoved;

			public static ActionEventType UserVoiced => aetUserVoiced;

			public static ActionEventType UserDevoiced => aetUserDevoiced;

			public static ActionEventType UserOpped => aetUserOpped;

			public static ActionEventType UserDeopped => aetUserDeopped;

			public static ActionEventType UserHalfOpped = aetUserHalfOpped;

			public static ActionEventType UserDehalfOpped => aetUserDehalfOpped;

			public static ActionEventType NickOfUserChanged => aetNickOfUserChanged;
		#endregion
	}
}