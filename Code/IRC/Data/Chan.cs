namespace BestChat.IRC.Data
{
	public class Chan
	{
		#region Constructors & Deconstructors
			public Chan(in ActiveNetwork anetOwner, in string strName)
			{
				this.anetOwner = anetOwner;
				this.strName = strName;

				// TODO: Get the real modes for the channel on this network
				foreach(Defs.ChanMode cmdCur in anetOwner.unetDef.ChanModesByModeChar.Values)
				{
					Mode<BoolModeState, BoolModeStates> modeNew = new(cmdCur,
						BoolModeState.off);

					mapModesOnChan[cmdCur.ModeChar] = modeNew;

					modeNew.evtStateChanged += OnStateOfModeChanged;

					foreach(Mode<BoolModeState, BoolModeStates>.Param mpCur in modeNew.AllParamsByName.Values)
						mpCur.evtValChanged += OnValOfModeParamChanged;
				}
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
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

			private readonly System.Collections.Generic.SortedDictionary<char, Mode<BoolModeState,
				BoolModeStates>> mapModesOnChan = new();

			// TODO: We need a way to update this map when the remote user's nick changes.
			private readonly System.Collections.Generic.SortedDictionary<string, RemoteUser>
				mapChanMembersByNick = new();
		#endregion

		#region Properties
			public ActiveNetwork Owner => anetOwner;

			public string Name => strName;

			public string ProperName => strName.StartsWith(chPrefix) ? strName : $"{chPrefix}{strName}";

			public string SafeName => System.Net.WebUtility.UrlEncode(ProperName);

			public string Path => $"{anetOwner.unetDef.Name}/Chan={strName}";


			public System.Collections.Generic.IReadOnlyDictionary<char, Mode<BoolModeState, BoolModeStates>>
				AllModesOnChan => mapModesOnChan;

			public System.Collections.Generic.IReadOnlyDictionary<string, RemoteUser> AllChanMembersByNick =>
				mapChanMembersByNick;
		#endregion

		#region Methods
			public override string? ToString() => strName;
		#endregion

		#region Event Handlers
			private void OnStateOfModeChanged(Mode<BoolModeState, BoolModeStates> modeSender, BoolModeState
				stateOld, BoolModeState stateNew)
			{
				// TODO: Attempt to change the mode on the network
			}

			private void OnValOfModeParamChanged(Mode<BoolModeState, BoolModeStates>.Param mpSender, object?
				objOldVal, object? objNewVal)
			{
				if(objNewVal != null)
				{
					// TODO: Attempt to change the mode on the network
				}
			}
		#endregion
	}
}