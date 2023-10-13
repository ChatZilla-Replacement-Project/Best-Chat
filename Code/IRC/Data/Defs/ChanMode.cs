// Ignore Spelling: dcm Defs

namespace BestChat.IRC.Data.Defs
{
	[System.ComponentModel.ImmutableObject(true)]
	public class ChanMode
	{
		#region Constructors & Deconstructors
			public ChanMode(DTO.ChanModeDTO dcmUs)
			{
				chModeChar = dcmUs.Mode;
				textDesc = new(dcmUs.LocalizedDesc, dcmUs.DefaultDesc);
				bNotAlwaysAvailable = dcmUs.NotAlwaysAvailable;
				foreach(DTO.ModeParamDTO dmpCurParam in dcmUs.Parameters)
					mapModesByName[dmpCurParam.Name] = new(dmpCurParam);
				strFmtAsSentToNetwork = dcmUs.FmtAsSentToNetwork;
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
			public readonly char chModeChar;

			public readonly LocalizedTextSystem textDesc;

			public readonly bool bNotAlwaysAvailable;

			private readonly System.Collections.Generic.SortedDictionary<string, ModeParam> mapModesByName = new
				();

			public readonly string strFmtAsSentToNetwork;
		#endregion

		#region Properties
			public char ModeChar => chModeChar;

			public LocalizedTextSystem Desc => textDesc;

			public bool NotAlwaysAvailable => bNotAlwaysAvailable;

			public System.Collections.Generic.IReadOnlyDictionary<string, ModeParam> ModesByName =>
				mapModesByName;

			public string FmtAsSentToNetwork => strFmtAsSentToNetwork;
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
		#endregion
	}
}