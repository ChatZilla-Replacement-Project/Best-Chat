// Ignore Spelling: pnet dpnetwork Defs

namespace BestChat.IRC.Data.Defs
{
	[System.ComponentModel.ImmutableObject(true)]
	public class PredefinedNetwork : Network
	{
		#region Constructors & Deconstructors
			public PredefinedNetwork()
			{
			}

			public PredefinedNetwork(in DTO.PredefinedNetworkDTO dpnetworkUs) : base(dpnetworkUs)
			{
				foreach(DTO.ChanModeDTO dcmCur in dpnetworkUs.Modes)
					mapModesByModeChar[dcmCur.Mode] = new(dcmCur);
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
			private readonly System.Collections.Generic.SortedDictionary<char, ChanMode> mapModesByModeChar =
				new();
		#endregion

		#region Properties
			public System.Collections.Generic.IReadOnlyDictionary<char, ChanMode> ModesByModeChar =>
				mapModesByModeChar;
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}