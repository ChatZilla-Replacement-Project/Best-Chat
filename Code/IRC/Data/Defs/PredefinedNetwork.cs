﻿// Ignore Spelling: pnet dpnetwork Defs

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
				foreach(DTO.ChanModeDTO dcmCur in dpnetworkUs.ChanModes)
					mapChanModesByModeChar[dcmCur.Mode] = new(dcmCur);
				foreach(DTO.UserModeDTO dumCur in dpnetworkUs.UserModes)
					mapUserModesByModeChar[dumCur.Mode] = new(dumCur);
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
			private readonly System.Collections.Generic.SortedDictionary<char, ChanMode> mapChanModesByModeChar
				= new();

			private readonly System.Collections.Generic.SortedDictionary<char, UserMode> mapUserModesByModeChar =
				new();
		#endregion

		#region Properties
			public override System.Collections.Generic.IReadOnlyDictionary<char, ChanMode> ChanModesByModeChar
				=> mapChanModesByModeChar;

			public override System.Collections.Generic.IReadOnlyDictionary<char, UserMode> UserModesByModeChar
				=> mapUserModesByModeChar;
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}