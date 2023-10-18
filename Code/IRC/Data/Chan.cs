// Ignore Spelling: evt

namespace BestChat.IRC.Data
{
	using Util.Ext;

	public class Chan : Platform.Conversations.AbstractConversation, Platform.TreeData.VisualTreeData
		.IItemInfo
	{
		#region Constructors & Deconstructors
			public Chan(in ActiveNetwork anetOwner, in string strName) : base(strName, Resources
				.strChanNameDescForTree.Fmt(strName, anetOwner.unetDef.Name))
			{
				this.anetOwner = anetOwner;
				this.strName = strName;

				// TODO: Get the real modes for the channel on this network
				foreach(Defs.ChanMode cmdCur in anetOwner.unetDef.ChanModesByModeChar.Values)
				{
					Defs.Mode<Defs.BoolModeState, Defs.BoolModeStates> modeNew = new
					 (cmdCur, Defs.BoolModeState.off);

					mapModesOnChan[cmdCur.ModeChar] = modeNew;

					modeNew.evtStateChanged += OnStateOfModeChanged;

					foreach(Defs.Mode<Defs.BoolModeState, Defs.BoolModeStates>.Param mpCur in modeNew
							.AllParamsByName.Values)
						mpCur.evtValChanged += OnValOfModeParamChanged;
				}
			}

			~Chan() => evtDieing?.Invoke(this);
		#endregion

		#region Delegates
		#endregion

		#region Events
			public override event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;

			public override event Platform.Common.IDieable.OnDieing? evtDieing;
		#endregion

		#region Constants
			public const char chPrefix = '#';

			public static readonly string strSafePrefix = System.Net.WebUtility.UrlEncode($"{chPrefix}") ??
				throw new System.InvalidProgramException("Unexpected failure to initialize strSafePrefix");
		#endregion

		#region Helper Types
		#endregion

		#region Members
			public readonly ActiveNetwork anetOwner;

			public readonly string strName;

			private readonly System.Collections.Generic.SortedDictionary<char, Defs.Mode<Defs.BoolModeState,
				Defs.BoolModeStates>> mapModesOnChan = new();

			// TODO: We need a way to update this map when the remote user's nick changes.
			private readonly System.Collections.Generic.SortedDictionary<string, RemoteUser>
				mapChanMembersByNick = new();
		#endregion

		#region Properties
			public ActiveNetwork Owner => anetOwner;

			public override string ProperName => strName.StartsWith(chPrefix) ? strName : $"{chPrefix}{strName}";

			public override string SafeName => System.Net.WebUtility.UrlEncode(ProperName);

			public override string Path => $"{anetOwner.unetDef.Name}/{Resources.strOneChannel}/{strName}";

			public override string LocalizedName => ProperName;

			public override string Icon => "🪟";


			public override Platform.Conversations.IViewOrConversation.Types Type => Platform.Conversations
				.IViewOrConversation.Types.channelOrRoom;


		public System.Collections.Generic.IReadOnlyDictionary<char, Defs.Mode<Defs.BoolModeState, Defs
			.BoolModeStates>> AllModesOnChan => mapModesOnChan;

			public System.Collections.Generic.IReadOnlyDictionary<string, RemoteUser> AllChanMembersByNick =>
				mapChanMembersByNick;
		#endregion

		#region Methods
			public override string? ToString() => strName;

			protected override void FirePropChanged(string strPropName) => PropertyChanged?.Invoke(this, new
				(strPropName));
		#endregion

		#region Event Handlers
			private void OnStateOfModeChanged(Defs.Mode<Defs.BoolModeState, Defs.BoolModeStates> modeSender,
				Defs.BoolModeState stateOld, Defs.BoolModeState stateNew)
			{
				// TODO: Attempt to change the mode on the network
			}

			private void OnValOfModeParamChanged(Defs.Mode<Defs.BoolModeState, Defs.BoolModeStates>.Param
				mpSender, object? objOldVal, object? objNewVal)
			{
				if(objNewVal != null)
				{
					// TODO: Attempt to change the mode on the network
				}
			}
		#endregion
	}
}