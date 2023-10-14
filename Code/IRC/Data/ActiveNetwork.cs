// Ignore Spelling: unet Chans

namespace BestChat.IRC.Data
{
	public class ActiveNetwork : System.ComponentModel.INotifyPropertyChanged
	{
		#region Constructors & Deconstructors
			public ActiveNetwork(in Defs.UserNetwork unetDef)
			{
				this.unetDef = unetDef;

				// TODO: Figure out how to actually connect.

				// TODO: Determine how to get the user's real nick
				ru = new(this, "UserNick", mapModesOnUser.Values, System.Array.Empty<Chan>()); 


				// TODO: Get the real modes for the user on this network
				foreach(Defs.UserMode cmdCur in unetDef.UserModesByModeChar.Values)
				{
					Mode<BoolModeState, BoolModeStates> modeNew = new(cmdCur,
						BoolModeState.off);

					mapModesOnUser[cmdCur.ModeChar] = modeNew;

					modeNew.evtStateChanged += OnStateOfModeChanged;
				}
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
			public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
		#endregion

		#region Constants
		#endregion

		#region Helper Types
		#endregion

		#region Members
			public readonly Defs.UserNetwork unetDef;

			private readonly System.Collections.Generic.SortedDictionary<string, Chan> mapChansByName = new
				();

			private readonly RemoteUser ru;

			private readonly System.Collections.Generic.SortedDictionary<char, Mode<BoolModeState,
				BoolModeStates>> mapModesOnUser = new();

			// TODO: Remove this attribute once the field is functional
			[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly " +
				"modifier", Justification = "Field not yet implemented")]
			private System.Uri uriConnectedTo;

			// TODO: We need a way to update this map when the remote user's nick changes.
			private readonly System.Collections.Generic.SortedDictionary<string, RemoteUser>
				mapChanMembersByNick = new();
		#endregion

		#region Properties
			public Defs.UserNetwork Def => unetDef;

			public System.Collections.Generic.IReadOnlyDictionary<string, Chan> AllChansByName =>
				mapChansByName;

			// TODO: We need a way to update the nick on this user.
			public RemoteUser UserInfo => ru;

			public System.Collections.Generic.IReadOnlyDictionary<char, Mode<BoolModeState, BoolModeStates>>
				AllModesOnUser => mapModesOnUser;

			public System.Uri ConnectedTo => uriConnectedTo;

			public System.Collections.Generic.IReadOnlyDictionary<string, RemoteUser> AllKnownUsersByNick =>
				mapChanMembersByNick;
		#endregion

		#region Methods
			private void FirePropChanged(string strWhichProp) => PropertyChanged?.Invoke(this, new
				(strWhichProp));
		#endregion

		#region Event Handlers
			private void OnStateOfModeChanged(Mode<BoolModeState, BoolModeStates> modeSender, BoolModeState
				stateOld, BoolModeState stateNew)
			{
				// TODO: Attempt to change the mode on the network
			}
		#endregion
	}
}