// Ignore Spelling: evt

namespace BestChat.IRC.Data
{
	using Util.Ext;

	public class ConversationWithRemoteUser : Platform.Conversations.AbstractConversation, Platform.TreeData
		.VisualTreeData.IItemInfo
	{
		#region Constructors & Deconstructors
			public ConversationWithRemoteUser(in ActiveNetwork anetOwner, in RemoteUser ru) : base(ru.CurNick,
				Resources.strRemoteUserDescForTree.Fmt(ru.CurNick, anetOwner.Name))
			{
				if(ru == anetOwner.ru)
					throw new System.InvalidProgramException("A ConversationWithRemoteUser was created, but" +
						$" it's parent, {anetOwner.Name}, happens to be the same remote user: {ru.CurNick}");

				this.anetOwner = anetOwner;
				this.ru = ru;
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
			public override event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;

			public override event Platform.Common.IDieable.OnDieing? evtDieing;
		#endregion

		#region Constants
		#endregion

		#region Helper Types
		#endregion

		#region Members
			public readonly ActiveNetwork anetOwner;

			public readonly RemoteUser ru;
		#endregion

		#region Properties
			public override string ProperName => ru.CurNick;

			public override string SafeName => ru.CurNick;

			public override string Path => $"{anetOwner.Name}/{Resources.strConversationGroupTypeRemoteUsers}/{
				ru.CurNick}";

			public override string LocalizedName => ru.CurNick;

			public override string Icon => "🧑";

			public override Platform.Conversations.IViewOrConversation.Types Type => Platform.Conversations
				.IViewOrConversation.Types.user;
		#endregion

		#region Methods
			protected override void FirePropChanged(string strPropName) => PropertyChanged?.Invoke(this, new
				(strPropName));
		#endregion

		#region Event Handlers
		#endregion
	}
}